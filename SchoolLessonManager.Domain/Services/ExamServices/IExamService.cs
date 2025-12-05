using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Services.ExamServices
{
    public interface IExamService
    {
        Task<Response<Exam>> AddExamAsync(Exam exam);
        Task<Response<List<Exam>>> GetFilteredAsync(string? lesson, string? student,
                                     DateTime? from, DateTime? to);
    }
}
