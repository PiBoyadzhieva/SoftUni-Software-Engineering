using System;
using System.Collections.Generic;
using System.Linq;
using BandRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace BandRegister.Data
{
    public class BandRegisterDbContext: DbContext
    {
        public DbSet<Band> Bands { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BandRegisterDb;Integrated Security = True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlServer(ConnectionString);
        }
    }
}
