using SchoolLessonManager.Domain.Entities;

namespace SchoolLessonManager.Domain.Repositories.LessonRepositories
{
    public interface ILessonRepository
    {
        Task AddAsync(Lesson lesson);
        Task<Lesson?> GetByCodeAsync(string code);
        IQueryable<Lesson> GetAllQueryable();
    }
}
