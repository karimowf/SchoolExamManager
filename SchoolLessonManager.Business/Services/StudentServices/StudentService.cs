using Microsoft.EntityFrameworkCore;
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
            try
            {
                var existingStudent = await unitOfWork.StudentRepository.GetByNumberAsync(student.Number);

                if (existingStudent != null)
                {
                    return Response<Student>.Fail($"Bu nömrə ilə şagird artıq mövcuddur: {student.Number}.",
                        HttpStatusCode.BadRequest.GetHashCode());
                }

                await unitOfWork.StudentRepository.AddAsync(student);
                await unitOfWork.CommitAsync();

                return Response<Student>.Success(student, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return Response<Student>.Fail(ex.Message ?? "Gözlənilməz xəta baş verdi", HttpStatusCode.BadRequest.GetHashCode());
            }
        }

        public async Task<Response<Student>> GetByNumberAsync(int? number)
        {
            try
            {
                var student = await unitOfWork.StudentRepository.GetByNumberAsync(number);

                if (student == null)
                {
                    return Response<Student>.Fail(
                        "Şagird tapılmadı",
                        HttpStatusCode.BadRequest.GetHashCode()
                    );
                }

                return Response<Student>.Success(
                    student,
                    HttpStatusCode.OK.GetHashCode()
                );
            }
            catch (Exception ex)
            {
                return Response<Student>.Fail(ex.Message ?? "Gözlənilməz xəta baş verdi", HttpStatusCode.BadRequest.GetHashCode());
            }
        }

        public async Task<Response<List<Student>>> GetFilteredAsync(string? number, string? first, string? last, int? grade)
        {
            try
            {
                var query = unitOfWork.StudentRepository.GetAllQueryable();

                if (!string.IsNullOrWhiteSpace(number) && int.TryParse(number, out int num))
                    query = query.Where(s => s.Number == num);

                if (!string.IsNullOrWhiteSpace(first))
                    query = query.Where(s => s.FirstName.Contains(first));

                if (!string.IsNullOrWhiteSpace(last))
                    query = query.Where(s => s.LastName.Contains(last));

                if (grade.HasValue)
                    query = query.Where(s => s.GradeLevel == grade.Value);

                var data = await query.ToListAsync();

                return Response<List<Student>>.Success(data, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return Response<List<Student>>.Fail(ex.Message ?? "Gözlənilməz xəta baş verdi", 
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
