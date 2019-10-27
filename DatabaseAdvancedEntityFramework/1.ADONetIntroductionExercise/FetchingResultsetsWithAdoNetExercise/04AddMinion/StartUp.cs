using System;
using System.Data.SqlClient;

namespace _04AddMinion
{
    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS01;Database=MinionsDB;Integrated Security=True";

        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main()
        {
            string[] minionInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] villainInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];
            string villainName = villainInfo[1];

            connection.Open();

            using (connection)
            {
                int? townId = GetTownByName(townName, connection);

                if (townId is null)
                {
                    AddTown(connection, townName);
                }

                townId = GetTownByName(townName, connection);

                AddMinion(connection, minionName, minionAge, townId);
                int minionId = GetMinionByName(minionName, connection);

                int? villainId = GetVillainByName(villainName, connection);

                if(villainId == null)
                {
                    AddVillain(connection, villainName);
                }

                villainId = GetVillainByName(villainName, connection);

                AddMinionVillain(connection, villainId, minionId, minionName, villainName);
            }
        }
        private static void AddMinionVillain(SqlConnection connection, int? villainId, int minionId, string minionName, string villainName)
        {
            using (SqlCommand command = new SqlCommand(Queries.InsertMinionsVillains, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", (int)minionId);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
        private static int GetMinionByName(string minionName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.minionId, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int)command.ExecuteScalar();
            }
        }
        private static void AddVillain(SqlConnection connection, string villainName)
        {
            using (SqlCommand insertVillainCmd = new SqlCommand(Queries.InsertVillain, connection))
            {
                insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCmd.ExecuteNonQuery();
            }

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }
        private static int? GetVillainByName(string villainName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.villainId, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);

                return (int?)command.ExecuteScalar();
            }
        }
        private static void AddMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            using (SqlCommand insertMinion = new SqlCommand(Queries.InsertMinion, connection))
            {
                insertMinion.Parameters.AddWithValue("@name", minionName);
                insertMinion.Parameters.AddWithValue("@age", minionAge);
                insertMinion.Parameters.AddWithValue("@townId", townId);

                insertMinion.ExecuteNonQuery();
            }
        }
        private static int? GetTownByName(string townName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.townId, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);

                return (int?)command.ExecuteScalar();

            }
        }
        private static void AddTown(SqlConnection connection, string townName)
        {
            using (SqlCommand insertTown = new SqlCommand(Queries.InsertTown, connection))
            {
                insertTown.Parameters.AddWithValue("@townName", townName);
                insertTown.ExecuteNonQuery();
            }

            Console.WriteLine($"Town {townName} was added to the database.");
        }
    }
}
