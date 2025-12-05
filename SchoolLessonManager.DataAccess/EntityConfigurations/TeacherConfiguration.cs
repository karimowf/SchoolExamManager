using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.DataAccess.EntityConfigurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.FirstName)
                   .HasMaxLength(20);

            builder.Property(t => t.LastName)
                   .HasMaxLength(20);
        }
    }
}
