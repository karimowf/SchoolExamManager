using Microsoft.AspNetCore.Mvc;
using SchoolLessonManager.Domain.Entities;
using SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.StudentServices;
using SchoolLessonManager.Presentation.Models.Students;

namespace SchoolLessonManager.Presentation.Controllers
{
    public class StudentController(IStudentRegistrationService studentRegistrationService, IStudentService studentService) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var student = new Student
            {
                Number = model.Number,
                FirstName = model.FirstName,
                LastName = model.LastName,
                GradeLevel = model.GradeLevel
            };

            var response = await studentRegistrationService.RegisterAsync(student);

            if (!response.IsSuccessfully)
            {
                var error = response.Errors?.FirstOrDefault() ?? "Unknown error";
                ModelState.AddModelError("", error);
                return View(model);
            }

            return RedirectToAction("Create", "Exam");
        }

        [HttpGet]
        public async Task<IActionResult> List(StudentFilterViewModel filter)
        {
            var students = await studentService.GetFilteredAsync(
                filter.Number,
                filter.First,
                filter.Last,
                filter.Grade);

            return View(students);
        }
    }
}
