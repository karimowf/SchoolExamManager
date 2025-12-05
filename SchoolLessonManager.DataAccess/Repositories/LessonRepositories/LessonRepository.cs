using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.DataAccess.DbContexts;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Repositories.LessonRepositories;

namespace SchoolLessonManager.DataAccess.Repositories.LessonRepositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly SchoolLessonManagerDbContext _context;

        public LessonRepository(SchoolLessonManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }

        public IQueryable<Lesson> GetAllQueryable()
        {
            return _context.Lessons.AsQueryable();
        }


        public async Task<Lesson?> GetByCodeAsync(string code)
        {
            return await _context.Lessons
                                   .FirstOrDefaultAsync(l => l.Code == code);
        }
    }
}
