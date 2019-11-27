namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;
    using System;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> homework)
        {
            homework
                .HasKey(k => k.HomeworkId);

            homework
                .Property(p => p.Content)
                .IsUnicode(false)
                .IsRequired(true);

            homework
                .Property(p => p.ContentType)
                .IsRequired(true);

            homework
                .Property(p => p.SubmissionTime)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired(true);

            homework
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

            homework
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
        }
    }
}
