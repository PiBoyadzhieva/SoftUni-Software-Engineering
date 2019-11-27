namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .HasKey(k => k.UserId);

            user
                .Property(p => p.Name)
                .HasMaxLength(100);

            user.Property(p => p.Username)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

            user.Property(p => p.Password)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(false);

            user.Property(p => p.Email)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(30);
        }
    }
}
