using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.ExamServices;
using SchoolLessonManager.Domain.Services.LessonServices;
using SchoolLessonManager.Domain.Services.RegistrationServices.SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.StudentServices;
using SchoolLessonManager.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Response<Exam>> RegisterAsync(Exam exam, string lessonCode, int studentNumber)
        {
            var lesson = await _lessonService.GetByCodeAsync(lessonCode);
            if (lesson.Data == null)
                return Response<Exam>.Fail("Lesson not found", HttpStatusCode.BadRequest.GetHashCode());

            var student = await _studentService.GetByNumberAsync(studentNumber);
            if (student.Data == null)
                return Response<Exam>.Fail("Student not found", HttpStatusCode.BadRequest.GetHashCode());

            exam.LessonId = lesson.Data.Id;
            exam.StudentId = student.Data.Id;

            var response = await _examService.AddExamAsync(exam);

            if (!response.IsSuccessfully)
            {
                var error = response.Errors?.FirstOrDefault() ?? "Unknown error";
                return Response<Exam>.Fail(error, HttpStatusCode.BadRequest.GetHashCode());
            }

            var examData = response.Data;
            if (examData == null)
            {
                return Response<Exam>.Fail("Exam data is null", HttpStatusCode.BadRequest.GetHashCode());
            }

            return Response<Exam>.Success(examData, HttpStatusCode.OK.GetHashCode());
        }
    }
}
