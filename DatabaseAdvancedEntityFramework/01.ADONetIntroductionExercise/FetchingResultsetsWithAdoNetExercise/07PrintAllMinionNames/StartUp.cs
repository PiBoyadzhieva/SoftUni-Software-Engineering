using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07PrintAllMinionNames
{
    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main()
        {
            List<string> names = new List<string>();

            using (connection)
            {
                connection.Open();

                string sqlQuery = @"SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add((string)reader[0]);
                        }
                    }
                }
            }

            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count - i -1]);
            }

            if(names.Count % 2 != 0)
            {
                Console.WriteLine(names.Count/2);
            }
        }
    }
}
