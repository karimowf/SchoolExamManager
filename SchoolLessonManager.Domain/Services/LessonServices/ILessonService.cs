using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Services.LessonServices
{
    public interface ILessonService
    {
        Task<Response<Lesson>> AddLessonAsync(Lesson lesson);
        Task<Response<Lesson>> GetByCodeAsync(string code);
    }
}
