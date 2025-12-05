using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.Domain.Repositories.ExamRepositories
{
    public interface IExamRepository
    {
        Task AddExamAsync(Exam exam);
        IQueryable<Exam> GetAllQueryable();
    }
}
