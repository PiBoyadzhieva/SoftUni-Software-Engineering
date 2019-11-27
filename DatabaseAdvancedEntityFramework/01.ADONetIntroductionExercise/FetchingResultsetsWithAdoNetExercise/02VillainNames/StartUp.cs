using System;
using System.Data.SqlClient;

namespace _02VillainNames
{
    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main()
        {
            connection.Open();

            using (connection)
            {
                string queryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount 
                                     FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                     GROUP BY v.Id, v.Name 
                                     HAVING COUNT(mv.VillainId) > 3 
                                     ORDER BY COUNT(mv.VillainId)";

                SqlCommand command = new SqlCommand(queryText, connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = reader["Name"];
                        var minionsCount = reader["MinionsCount"];

                        Console.WriteLine($"{name} - {minionsCount}");
                    }
                }
            }
        }
    }
}
