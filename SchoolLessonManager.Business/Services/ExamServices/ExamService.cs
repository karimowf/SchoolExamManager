using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.ExamServices;
using SchoolLessonManager.Domain.UnitOfWorks;
using SchoolLessonManager.Shared.Responses;
using System.Net;

namespace SchoolLessonManager.Business.Services.ExamServices
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Exam>> AddExamAsync(Exam exam)
        {
            await _unitOfWork.ExamRepository.AddExamAsync(exam);
            await _unitOfWork.CommitAsync();

            return Response<Exam>.Success(exam, HttpStatusCode.OK.GetHashCode());
        }

        public async Task<List<Exam>> GetFilteredAsync(
       string? lesson,
       string? student,
       DateTime? from,
       DateTime? to)
        {
            var query = _unitOfWork.ExamRepository.GetAllQueryable();

            if (!string.IsNullOrWhiteSpace(lesson))
            {
                query = query.Where(e =>
                    e.Lesson.Name.Contains(lesson) ||
                    e.Lesson.Code.Contains(lesson));
            }

            if (!string.IsNullOrWhiteSpace(student))
            {
                query = query.Where(e =>
                    e.Student.FirstName.Contains(student) ||
                    e.Student.LastName.Contains(student));
            }

            if (from.HasValue)
                query = query.Where(e => e.ExamDate >= from.Value);

            if (to.HasValue)
                query = query.Where(e => e.ExamDate <= to.Value);

            return await query.ToListAsync();
        }
    }
}
