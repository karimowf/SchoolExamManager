using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.DataAccess.DbContexts;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Repositories.ExamRepositories;

namespace SchoolLessonManager.DataAccess.Repositories.ExamRepositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly SchoolLessonManagerDbContext _dbContext;

        public ExamRepository(SchoolLessonManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddExamAsync(Exam exam)
        {
            await _dbContext.Exams.AddAsync(exam);
        }

        public IQueryable<Exam> GetAllQueryable()
        {
            return _dbContext.Exams
                .Include(e => e.Lesson)
                .Include(e => e.Student)
                .AsQueryable();
        }
    }
}
