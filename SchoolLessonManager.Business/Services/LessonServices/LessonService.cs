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
