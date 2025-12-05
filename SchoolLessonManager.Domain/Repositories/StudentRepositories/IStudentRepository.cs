using SchoolLessonManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Repositories.StudentRepositories
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<Student?> GetByNumberAsync(int number);
    }
}
