using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GameStoreDbContext: DbContext
    {
        public DbSet<Game> Games { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=GameStoreDb;Integrated Security = True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlServer(ConnectionString);
        }
    }
}
