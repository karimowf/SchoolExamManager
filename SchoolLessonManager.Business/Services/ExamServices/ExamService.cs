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
    }
}
