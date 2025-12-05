using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.LessonServices;
using SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.TeacherServices;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.RegistrationServices
{
    public class LessonRegistrationService : ILessonRegistrationService
    {
        private readonly ITeacherService _teacherService;
        private readonly ILessonService _lessonService;

        public LessonRegistrationService(ITeacherService teacherService, ILessonService lessonService)
        {
            _teacherService = teacherService;
            _lessonService = lessonService;
        }

        public async Task<Response<Lesson>> RegisterAsync(Lesson lesson, Teacher teacher)
        {
            var teacherResponse = await _teacherService.GetByNameAsync(teacher.FirstName, teacher.LastName);

            Teacher finalTeacher;

            if (teacherResponse.IsSuccessfully)
            {
                if (teacherResponse.Data is null)
                    return Response<Lesson>.Fail("Teacher data is null", HttpStatusCode.BadRequest.GetHashCode());

                finalTeacher = teacherResponse.Data;
            }
            else
            {
                var addTeacherResponse = await _teacherService.AddTeacherAsync(teacher);

                if (!addTeacherResponse.IsSuccessfully)
                    return Response<Lesson>.Fail(addTeacherResponse.Errors?.FirstOrDefault() ?? "Unknown error",
                        HttpStatusCode.BadRequest.GetHashCode());

                if (addTeacherResponse.Data is null)
                    return Response<Lesson>.Fail("Teacher data is null", HttpStatusCode.BadRequest.GetHashCode());

                finalTeacher = addTeacherResponse.Data;
            }

            lesson.TeacherId = finalTeacher.Id;

            var addLessonResponse = await _lessonService.AddLessonAsync(lesson);

            if (!addLessonResponse.IsSuccessfully)
                return Response<Lesson>.Fail(addLessonResponse.Errors?.FirstOrDefault() ?? "Unknown error",
                    HttpStatusCode.BadRequest.GetHashCode());

            if (addLessonResponse.Data is null)
                return Response<Lesson>.Fail("Teacher data is null", HttpStatusCode.BadRequest.GetHashCode());

            return Response<Lesson>.Success(addLessonResponse.Data, HttpStatusCode.OK.GetHashCode());
        }

    }

}
