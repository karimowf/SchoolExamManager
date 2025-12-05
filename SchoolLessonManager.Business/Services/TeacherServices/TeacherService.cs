using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.TeacherServices;
using SchoolLessonManager.Domain.UnitOfWorks;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.TeacherServices
{
    public class TeacherService(IUnitOfWork unitOfWork) : ITeacherService
    {
        public async Task<Response<Teacher>> AddTeacherAsync(Teacher teacher)
        {
            await unitOfWork.TeacherRepository.AddTeacherAsync(teacher);
            await unitOfWork.CommitAsync();
            return Response<Teacher>.Success(teacher, HttpStatusCode.OK.GetHashCode());
        }

        public async Task<Response<Teacher>> GetByNameAsync(string firstName, string lastName)
        {
            var teacher = await unitOfWork.TeacherRepository.GetByNameAsync(firstName, lastName);

            if (teacher is null)
                return Response<Teacher>.Fail("Teacher not found.", HttpStatusCode.BadRequest.GetHashCode());

            return Response<Teacher>.Success(teacher, HttpStatusCode.OK.GetHashCode());
        }
    }
}
