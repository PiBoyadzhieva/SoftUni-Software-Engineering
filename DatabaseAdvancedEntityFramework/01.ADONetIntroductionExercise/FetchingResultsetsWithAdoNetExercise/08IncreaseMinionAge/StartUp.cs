using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08IncreaseMinionAge
{
    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);
        public static void Main()
        {
            int[] ids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            using (connection)
            {
                connection.Open();

                string sqlQuery = @"UPDATE Minions
                                      SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                      WHERE Id = @Id";

                for (int i = 0; i < ids.Length; i++)
                {
                    int currentId = ids[1];

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", currentId);
                        command.ExecuteNonQuery();
                    }
                }

                string minionsQuery = @"SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader["Name"];
                            int age = (int)reader["Age"];

                            Console.WriteLine($"{name} {age}");
                        }
                    }
                }
            }
        }
    }
}
