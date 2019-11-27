using System;
using System.Data.SqlClient;

namespace _09IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                connection.Open();

                string uspGetOlderProc = "EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(uspGetOlderProc, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} – {age} years old");
                    }
                }
            }
        }
    }
}
