using SchoolLessonManager.DataAccess.DbContexts;
using SchoolLessonManager.DataAccess.Repositories.ExamRepositories;
using SchoolLessonManager.DataAccess.Repositories.LessonRepositories;
using SchoolLessonManager.DataAccess.Repositories.StudentRepositories;
using SchoolLessonManager.DataAccess.Repositories.TeacherRepositories;
using SchoolLessonManager.Domain.Repositories.ExamRepositories;
using SchoolLessonManager.Domain.Repositories.LessonRepositories;
using SchoolLessonManager.Domain.Repositories.StudentRepositories;
using SchoolLessonManager.Domain.Repositories.TeacherRepositories;
using SchoolLessonManager.Domain.UnitOfWorks;

namespace SchoolLessonManager.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolLessonManagerDbContext _context;
        private TeacherRepository? _teacherRepository;
        private LessonRepository? _lessonRepository;
        private StudentRepository? _studentRepository;
        private ExamRepository? _examRepository;

        public UnitOfWork(SchoolLessonManagerDbContext dbContext)
        {
            _context = dbContext;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public ITeacherRepository TeacherRepository => _teacherRepository ??= new TeacherRepository(_context);
        public ILessonRepository LessonRepository => _lessonRepository ??= new LessonRepository(_context);
        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context);
        public IExamRepository ExamRepository => _examRepository ??= new ExamRepository(_context);
    }
}
