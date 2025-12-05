using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;

namespace SchoolLessonManager.Domain.Services.RegistrationServices
{
    public interface IStudentRegistrationService
    {
        Task<Response<Student>> RegisterAsync(Student student);
    }
}
