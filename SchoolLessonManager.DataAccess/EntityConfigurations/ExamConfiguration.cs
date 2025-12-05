using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.DataAccess.EntityConfigurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.ExamDate)
                   .HasColumnType("date");

            builder.Property(e => e.Score)
                   .HasPrecision(1, 0);  

            builder.HasOne(e => e.Lesson)
                   .WithMany(l => l.Exams)
                   .HasForeignKey(e => e.LessonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Exams)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
