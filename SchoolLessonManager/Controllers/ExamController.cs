using Microsoft.AspNetCore.Mvc;
using SchoolLessonManager.Business.Services.ExamServices;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.ExamServices;
using SchoolLessonManager.Domain.Services.RegistrationServices.SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Presentation.Models.Exams;

namespace SchoolLessonManager.Presentation.Controllers
{
    public class ExamController(IExamRegistrationService examRegistrationService, IExamService examService) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var exam = new Exam
            {
                ExamDate = model.ExamDate,
                Score = model.Score,
            };

            var response = await examRegistrationService.RegisterAsync(
                exam,
                model.LessonCode,
                model.StudentNumber
            );

            if (!response.IsSuccessfully)
            {
                var error = response.Errors?.FirstOrDefault() ?? "Unknown error";
                ModelState.AddModelError("", error);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> List(ExamFilterViewModel filter)
        {
            var exams = await examService.GetFilteredAsync(
                filter.Lesson,
                filter.Student,
                filter.From,
                filter.To);

            return View(exams);
        }
    }
}
