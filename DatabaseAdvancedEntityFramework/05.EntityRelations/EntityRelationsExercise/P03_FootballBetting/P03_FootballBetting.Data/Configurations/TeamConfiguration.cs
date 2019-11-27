namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        {
            team
                .HasKey(k => k.TeamId);

            team
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            team
                .Property(p => p.LogoUrl)
                .HasMaxLength(250)
                .IsUnicode(false);

            team
                .Property(p => p.Initials)
                .HasMaxLength(3)
                .IsRequired(true)
                .IsUnicode(true);

            team
                .Property(p => p.Budget)
                .IsRequired(true);

            team
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            team
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            team
                .HasOne(t => t.Town)
                .WithMany(town => town.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}
