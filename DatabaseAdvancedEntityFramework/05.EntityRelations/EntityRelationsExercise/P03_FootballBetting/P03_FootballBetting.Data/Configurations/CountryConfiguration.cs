namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> country)
        {
            country
                .HasKey(k => k.CountryId);

            country
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}
