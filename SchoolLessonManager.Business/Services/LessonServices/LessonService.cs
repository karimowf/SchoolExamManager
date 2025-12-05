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
            var existLesson = await unitOfWork.LessonRepository.GetByCodeAsync(lesson.Code);
            if (existLesson != null)
            {
                return Response<Lesson>.Fail(
                    "A lesson with this code already exists.",
                    HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            await unitOfWork.LessonRepository.AddAsync(lesson);
            await unitOfWork.CommitAsync();

            return Response<Lesson>.Success(lesson, HttpStatusCode.OK.GetHashCode());
        }

        public async Task<List<Lesson>> GetFilteredAsync(string? code, string? name, string? teacher, int? grade)
        {
            var query = unitOfWork.LessonRepository
    .GetAllQueryable()
    .AsQueryable();

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

            return await query.ToListAsync();
        }



        public async Task<Response<Lesson>> GetByCodeAsync(string code)
        {
            var lesson = await unitOfWork.LessonRepository.GetByCodeAsync(code);

            if (lesson == null)
            {
                return Response<Lesson>.Fail(
                    "Lesson not found.",
                    HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            return Response<Lesson>.Success(
                lesson,
                HttpStatusCode.OK.GetHashCode()
            );
        }
    }
}
