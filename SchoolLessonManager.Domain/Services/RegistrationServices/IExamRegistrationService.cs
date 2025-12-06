using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Services.RegistrationServices
{
    namespace SchoolLessonManager.Domain.Services.RegistrationServices
    {
        public interface IExamRegistrationService
        {
            Task<Response<Exam>> RegisterAsync(Exam exam, string lessonCode, int? studentNumber, string? sessionLesson,
                    int? sessionStudent);
        }
    }
}
