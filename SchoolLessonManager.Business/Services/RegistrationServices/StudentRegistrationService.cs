using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.StudentServices;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.RegistrationServices
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private readonly IStudentService _studentService;

        public StudentRegistrationService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Response<Student>> RegisterAsync(Student student)
        {
            try
            {
                var response = await _studentService.AddAsync(student);

                if (!response.IsSuccessfully)
                {
                    var error = response.Errors?.FirstOrDefault() ?? "Naməlum xəta";
                    return Response<Student>.Fail(error, HttpStatusCode.BadRequest.GetHashCode());
                }

                if (response.Data == null)
                    return Response<Student>.Fail("Şagird məlumatı boşdu", HttpStatusCode.BadRequest.GetHashCode());

                return Response<Student>.Success(response.Data, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return Response<Student>.Fail(ex.Message ?? "Gözlənilməz xəta baş verdi", HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
