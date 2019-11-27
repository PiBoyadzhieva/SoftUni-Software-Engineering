namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> playerStatistic)
        {
            playerStatistic
                .HasKey(k => new { k.GameId, k.PlayerId });

            playerStatistic
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);

            playerStatistic
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);
        }
    }
}
