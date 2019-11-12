namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course
                .HasKey(k => k.CourseId);

            course
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);

            course
                .Property(p => p.Description)
                .IsUnicode(true)
                .IsRequired(false);

            course
                .Property(p => p.StartDate)
                .HasColumnType("DATE")
                .IsRequired(true);

            course
                .Property(p => p.EndDate)
                .HasColumnType("DATE")
                .IsRequired(true);

            course
                .Property(p => p.Price)
                .IsRequired(true);
        }
    }
}
