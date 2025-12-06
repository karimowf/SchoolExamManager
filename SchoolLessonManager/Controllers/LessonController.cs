using Microsoft.AspNetCore.Mvc;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.LessonServices;
using SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Presentation.Models.Lessons;

namespace SchoolLessonManager.Presentation.Controllers
{
    public class LessonController(ILessonRegistrationService lessonRegistrationService, ILessonService lessonService) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(LessonViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var teacher = new Teacher
            {
                FirstName = model.TeacherFirstName,
                LastName = model.TeacherLastName
            };

            var lesson = new Lesson
            {
                Code = model.Code,
                Name = model.Name,
                GradeLevel = model.GradeLevel
            };

            var response = await lessonRegistrationService.RegisterAsync(lesson, teacher);

            if (!response.IsSuccessfully)
            {
                var error = response.Errors?.FirstOrDefault() ?? "Naməlum xəta";
                ModelState.AddModelError("", error);
                return View(model);
            }

            HttpContext.Session.SetString("LessonCode", model.Code);


            return RedirectToAction("Create", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> List(LessonFilterViewModel filter)
        {
            var lessons = await lessonService.GetFilteredAsync(
                filter.Code,
                filter.Name,
                filter.Teacher,
                filter.Grade);

            return View(lessons.Data);
        }
    }
}
