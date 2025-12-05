using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.LessonServices;
using SchoolLessonManager.Domain.UnitOfWorks;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.LessonServices
{
    public class LessonService(IUnitOfWork unitOfWork) : ILessonService
    {
        public async Task<Response<Lesson>> AddLessonAsync(Lesson lesson)
        {
            try
            {
                var existLesson = await unitOfWork.LessonRepository.GetByCodeAsync(lesson.Code);
                if (existLesson != null)
                {
                    return Response<Lesson>.Fail("Bu kod ilə artıq dərs mövcuddur.", HttpStatusCode.BadRequest.GetHashCode());
                }

                await unitOfWork.LessonRepository.AddAsync(lesson);
                await unitOfWork.CommitAsync();

                return Response<Lesson>.Success(lesson, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return Response<Lesson>.Fail(
            ex.Message ?? "Gözlənilməz xəta baş verdi", HttpStatusCode.BadRequest.GetHashCode());
            }
        }

        public async Task<Response<List<Lesson>>> GetFilteredAsync(string? code, string? name, string? teacher, int? grade)
        {
            try
            {
                var query = unitOfWork.LessonRepository.GetAllQueryable().AsQueryable();

                query = query.Include(l => l.Teacher);

                if (!string.IsNullOrWhiteSpace(code))
                    query = query.Where(l => l.Code.Contains(code));

                if (!string.IsNullOrWhiteSpace(name))
                    query = query.Where(l => l.Name.Contains(name));

                if (!string.IsNullOrWhiteSpace(teacher))
                {
                    query = query.Where(l =>
                        (l.Teacher.FirstName + " " + l.Teacher.LastName)
                            .Contains(teacher));
                }

                if (grade.HasValue)
                    query = query.Where(l => l.GradeLevel == grade.Value);

                var data = await query.ToListAsync();

                return Response<List<Lesson>>.Success(data, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return Response<List<Lesson>>.Fail( ex.Message ?? "Gözlənilməz xəta baş verdi",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }



        public async Task<Response<Lesson>> GetByCodeAsync(string code)
        {
            try
            {
                var lesson = await unitOfWork.LessonRepository.GetByCodeAsync(code);

                if (lesson == null)
                {
                    return Response<Lesson>.Fail(
                        "Dərs tapılmadı",
                        HttpStatusCode.BadRequest.GetHashCode()
                    );
                }

                return Response<Lesson>.Success(
                    lesson,
                    HttpStatusCode.OK.GetHashCode()
                );
            }
            catch (Exception ex)
            {
                return Response<Lesson>.Fail(ex.Message ?? "Gözlənilməz xəta baş verdi",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
