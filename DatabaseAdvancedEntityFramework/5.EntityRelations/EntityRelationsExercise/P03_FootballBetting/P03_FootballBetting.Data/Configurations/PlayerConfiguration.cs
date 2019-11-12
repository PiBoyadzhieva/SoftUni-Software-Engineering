namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> player)
        {
            player
                .HasKey(k => k.PlayerId);

            player
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            player
                .Property(p => p.SquadNumber)
                .HasMaxLength(3)
                .IsRequired(true)
                .IsUnicode(false);

            player
                .Property(p => p.IsInjured)
                .IsRequired(true);

            player
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            player
                .HasOne(p => p.Position)
                .WithMany(pos => pos.Players)
                .HasForeignKey(p => p.PositionId);
        }
    }
}
