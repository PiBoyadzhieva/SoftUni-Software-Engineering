namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet
                .HasKey(k => k.BetId);

            bet
                .Property(p => p.Prediction)
                .IsRequired(true);

            bet
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            bet
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
        }
    }
}
