using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Services.StudentServices
{
    public interface IStudentService
    {
        Task<Response<Student>> AddAsync(Student student);
        Task<Response<Student>> GetByNumberAsync(int number);
        Task<List<Student>> GetFilteredAsync(string? number, string? first, string? last, int? grade);
    }
}
