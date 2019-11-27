namespace _5.EnttyRelations.Data
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CarPurchase> Purchases { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public override int SaveChanges()
        {
            var entries = this.ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                var validationContext = new ValidationContext(entity);

                Validator.ValidateObject(entity, validationContext, true);
            }

            return base.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if(!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //builder.ApplyConfiguration(new MakeConfiguration());

            //builder.ApplyConfiguration(new CarConfigaration());

            //builder.ApplyConfiguration(new CarPurchaseConfiguration());

            //builder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
