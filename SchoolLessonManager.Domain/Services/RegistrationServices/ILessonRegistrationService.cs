using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Services.RegistrationServices
{
    public interface ILessonRegistrationService
    {
        Task<Response<Lesson>> RegisterAsync(Lesson lesson, Teacher teacher);
    }
}
