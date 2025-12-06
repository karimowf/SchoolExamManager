using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.ExamServices;
using SchoolLessonManager.Domain.Services.LessonServices;
using SchoolLessonManager.Domain.Services.RegistrationServices.SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.StudentServices;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.RegistrationServices
{
    public class ExamRegistrationService : IExamRegistrationService
    {
        private readonly ILessonService _lessonService;
        private readonly IStudentService _studentService;
        private readonly IExamService _examService;

        public ExamRegistrationService(
            ILessonService lessonService,
            IStudentService studentService,
            IExamService examService)
        {
            _lessonService = lessonService;
            _studentService = studentService;
            _examService = examService;
        }

        public async Task<Response<Exam>> RegisterAsync(Exam exam, string lessonCode, int? studentNumber, string? sessionLesson,
        int? sessionStudent)
        {
            try
            {
                if (sessionLesson != lessonCode)
                    return Response<Exam>.Fail("Daxil edilən dərs kodu əvvəlki mərhələdə seçilən dərslə uyğun gəlmir",
                        HttpStatusCode.BadRequest.GetHashCode());

                if (sessionStudent != studentNumber)
                    return Response<Exam>.Fail("Daxil edilən şagird nömrəsi əvvəlki mərhələdə seçilən şagirdlə uyğun gəlmir",
                        HttpStatusCode.BadRequest.GetHashCode());

                var lesson = await _lessonService.GetByCodeAsync(lessonCode);
                if (lesson.Data == null)
                    return Response<Exam>.Fail("Dərs tapılmadı", HttpStatusCode.BadRequest.GetHashCode());

                var student = await _studentService.GetByNumberAsync(studentNumber);
                if (student.Data == null)
                    return Response<Exam>.Fail("Şagird tapılmadı", HttpStatusCode.BadRequest.GetHashCode());

                exam.LessonId = lesson.Data.Id;
                exam.StudentId = student.Data.Id;

                var response = await _examService.AddExamAsync(exam);

                if (!response.IsSuccessfully)
                {
                    var error = response.Errors?.FirstOrDefault() ?? "Naməlum xəta";
                    return Response<Exam>.Fail(error, HttpStatusCode.BadRequest.GetHashCode());
                }

                var examData = response.Data;
                if (examData == null)
                {
                    return Response<Exam>.Fail("İmtahan məlumatı boşdur", HttpStatusCode.BadRequest.GetHashCode());
                }

                return Response<Exam>.Success(examData, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return Response<Exam>.Fail(ex.Message ?? "Gözlənilməz xəta baş verdi", HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
