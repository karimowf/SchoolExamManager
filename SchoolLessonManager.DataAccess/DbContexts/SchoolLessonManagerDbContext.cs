using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.DataAccess.EntityConfigurations;
using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.DataAccess.DbContexts
{
    public class SchoolLessonManagerDbContext : DbContext
    {
        public SchoolLessonManagerDbContext(DbContextOptions<SchoolLessonManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
