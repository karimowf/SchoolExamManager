using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.DataAccess.DbContexts;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Repositories.TeacherRepositories;

namespace SchoolLessonManager.DataAccess.Repositories.TeacherRepositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolLessonManagerDbContext _dbContext;

        public TeacherRepository(SchoolLessonManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _dbContext.AddAsync(teacher);
        }

        public async Task<Teacher?> GetByNameAsync(string firstName, string lastName)
        {
            return await _dbContext.Teachers
                                  .FirstOrDefaultAsync(t => t.FirstName == firstName && t.LastName == lastName);
        }
    }
}
