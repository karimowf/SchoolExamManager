using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.DataAccess.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.Number)
                   .HasPrecision(5, 0);

            builder.HasIndex(s => s.Number)
                   .IsUnique();

            builder.Property(s => s.FirstName)
                   .HasMaxLength(30);

            builder.Property(s => s.LastName)
                   .HasMaxLength(30);

            builder.Property(s => s.GradeLevel)
                   .HasPrecision(2, 0);
        }
    }
}
