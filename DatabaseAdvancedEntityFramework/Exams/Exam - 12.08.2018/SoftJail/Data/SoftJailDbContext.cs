﻿namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<Cell>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Cells)
                .HasForeignKey(c => c.DepartmentId);

            builder.Entity<Mail>()
                .HasOne(m => m.Prisoner)
                .WithMany(p => p.Mails)
                .HasForeignKey(m => m.PrisonerId);

            builder.Entity<Officer>()
                .HasOne(o => o.Department)
                .WithMany(d => d.Officers)
                .HasForeignKey(o => o.DepartmentId);

            builder.Entity<Prisoner>()
                .HasOne(p => p.Cell)
                .WithMany(c => c.Prisoners)
                .HasForeignKey(p => p.CellId);

            builder.Entity<OfficerPrisoner>(offPrisoner =>
            {
                offPrisoner
                .HasKey(k => new { k.OfficerId, k.PrisonerId });

                offPrisoner
                .HasOne(op => op.Prisoner)
                .WithMany(p => p.PrisonerOfficers)
                .HasForeignKey(op => op.PrisonerId);

                offPrisoner
                .HasOne(op => op.Officer)
                .WithMany(op => op.OfficerPrisoners)
                .HasForeignKey(op => op.OfficerId);
            });
		}
	}
}