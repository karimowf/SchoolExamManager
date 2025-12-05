using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;

namespace SchoolLessonManager.Domain.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<Response<Teacher>> GetByNameAsync(string firstName, string lastName);
        Task<Response<Teacher>> AddTeacherAsync(Teacher teacher);
    }
}
