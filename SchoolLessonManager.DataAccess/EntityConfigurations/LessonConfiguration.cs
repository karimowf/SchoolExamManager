using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.DataAccess.EntityConfigurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(l => l.Code)
                   .HasMaxLength(3)
                   .IsFixedLength()
                   .HasColumnType("char(3)");

            builder.HasIndex(l => l.Code)
                   .IsUnique();

            builder.Property(l => l.Name)
                   .HasMaxLength(30);

            builder.Property(l => l.GradeLevel)
                   .HasPrecision(2, 0);

            builder.HasOne(l => l.Teacher)
                  .WithMany(t => t.Lessons)
                  .HasForeignKey(l => l.TeacherId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
