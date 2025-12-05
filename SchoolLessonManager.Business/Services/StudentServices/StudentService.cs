using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.StudentServices;
using SchoolLessonManager.Domain.UnitOfWorks;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.StudentServices
{
    public class StudentService(IUnitOfWork unitOfWork) : IStudentService
    {
        public async Task<Response<Student>> AddAsync(Student student)
        {
            var existingStudent = await unitOfWork.StudentRepository.GetByNumberAsync(student.Number);

            if (existingStudent != null)
            {
                return Response<Student>.Fail(
                    $"Student with number {student.Number} already exists.",
                    HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            await unitOfWork.StudentRepository.AddAsync(student);
            await unitOfWork.CommitAsync();

            return Response<Student>.Success(student, HttpStatusCode.OK.GetHashCode());
        }

        public async Task<Response<Student>> GetByNumberAsync(int number)
        {
            var student = await unitOfWork.StudentRepository.GetByNumberAsync(number);

            if (student == null)
            {
                return Response<Student>.Fail(
                    "Student not found.",
                    HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            return Response<Student>.Success(
                student,
                HttpStatusCode.OK.GetHashCode()
            );
        }
    }
}
