using SchoolLessonManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLessonManager.Domain.Repositories.TeacherRepositories
{
    public interface ITeacherRepository
    {
       Task<Teacher> GetByNameAsync(string firstName, string lastName);
       Task AddTeacherAsync(Teacher teacher);
    }
}
