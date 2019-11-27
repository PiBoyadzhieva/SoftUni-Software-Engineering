using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05ChangeTownNamesCasing
{
    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main()
        {
            string countryName = Console.ReadLine();

            connection.Open();

            using (connection)
            {
                string updateTownNames = @"UPDATE Towns
                                         SET Name = UPPER(Name)
                                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} town names were affected.");
                }

                string townNamesQuery = @"SELECT t.Name 
                                        FROM Towns as t
                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                        WHERE c.Name = @countryName";

                List<string> towns = new List<string>();

                using (SqlCommand command = new SqlCommand(townNamesQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }
    }
}
