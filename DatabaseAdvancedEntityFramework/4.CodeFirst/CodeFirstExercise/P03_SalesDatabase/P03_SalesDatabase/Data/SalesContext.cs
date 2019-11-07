namespace P03_SalesDatabase.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConnection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurstionOnProduct(modelBuilder);

            ConfigurstionOnCustomer(modelBuilder);

            ConfigurationOnStore(modelBuilder);

            ConfigirationOnSale(modelBuilder);
        }

        private static void ConfigirationOnSale(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>(entity => 
                { 
                    entity
                        .HasKey(k => k.SaleId);

                    entity
                        .Property(p => p.Date)
                        .HasColumnType("DATETIME2")
                        .HasDefaultValueSql("GETDATE()")
                        .IsRequired(true);

                    entity
                        .HasOne(s => s.Product)
                        .WithMany(p => p.Sales)
                        .HasForeignKey(s => s.ProductId);

                    entity
                        .HasOne(s => s.Customer)
                        .WithMany(c => c.Sales)
                        .HasForeignKey(s => s.CustomerId);

                    entity
                        .HasOne(s => s.Store)
                        .WithMany(st => st.Sales)
                        .HasForeignKey(s => s.StoreId);
                });
        }

        private static void ConfigurationOnStore(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>(entity =>
                {
                    entity
                        .HasKey(k => k.StoreId);

                    entity
                        .Property(p => p.Name)
                        .HasMaxLength(80)
                        .IsRequired(true)
                        .IsUnicode(true);
                });
        }

        private static void ConfigurstionOnCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>(entity =>
                {
                    entity
                        .HasKey(k => k.CustomerId);

                    entity
                        .Property(p => p.Name)
                        .HasMaxLength(100)
                        .IsRequired(true)
                        .IsUnicode(true);

                    entity
                        .Property(p => p.Email)
                        .HasMaxLength(80)
                        .IsRequired(true)
                        .IsUnicode(false);

                    entity
                        .Property(p => p.CreditCardNumber)
                        .IsRequired(true)
                        .IsUnicode(false);
                });
        }

        private static void ConfigurstionOnProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>(entity =>
                {
                    entity
                        .HasKey(k => k.ProductId);

                    entity
                        .Property(p => p.Name)
                        .HasMaxLength(50)
                        .IsRequired(true)
                        .IsUnicode(true);

                    entity
                        .Property(p => p.Quantity)
                        .IsRequired(true);

                    entity
                        .Property(p => p.Price)
                        .IsRequired(true);

                    entity
                        .Property(p => p.Description)
                        .HasMaxLength(250)
                        .IsRequired(false)
                        .IsUnicode(true)
                        .HasDefaultValue("No description");
                });
        }
    }
}
