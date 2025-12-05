using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;

namespace SchoolLessonManager.Domain.Services.RegistrationServices
{
    public interface ILessonRegistrationService
    {
        Task<Response<Lesson>> RegisterAsync(Lesson lesson, Teacher teacher);
    }
}
