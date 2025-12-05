using Microsoft.AspNetCore.Mvc;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.RegistrationServices.SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Presentation.Models.Exams;

namespace SchoolLessonManager.Presentation.Controllers
{
    public class ExamController(IExamRegistrationService examRegistrationService) : Controller
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
    }
}
