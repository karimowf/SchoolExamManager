using SchoolLessonManager.Domain.Repositories.ExamRepositories;
using SchoolLessonManager.Domain.Repositories.LessonRepositories;
using SchoolLessonManager.Domain.Repositories.StudentRepositories;
using SchoolLessonManager.Domain.Repositories.TeacherRepositories;

namespace SchoolLessonManager.Domain.UnitOfWorks
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        ITeacherRepository TeacherRepository { get; }
        ILessonRepository LessonRepository { get; }
        IStudentRepository StudentRepository { get; }
        IExamRepository ExamRepository { get; }
    }
}
