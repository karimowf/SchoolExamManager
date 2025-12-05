using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.DataAccess.DbContexts;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Repositories.StudentRepositories;

namespace SchoolLessonManager.DataAccess.Repositories.StudentRepositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolLessonManagerDbContext _context;

        public StudentRepository(SchoolLessonManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task<Student?> GetByNumberAsync(int number)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.Number == number);
        }
    }

}
