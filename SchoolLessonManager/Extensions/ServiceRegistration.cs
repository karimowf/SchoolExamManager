using SchoolLessonManager.Business.Services.ExamServices;
using SchoolLessonManager.Business.Services.LessonServices;
using SchoolLessonManager.Business.Services.RegistrationServices;
using SchoolLessonManager.Business.Services.StudentServices;
using SchoolLessonManager.Business.Services.TeacherServices;
using SchoolLessonManager.DataAccess.UnitOfWorks;
using SchoolLessonManager.Domain.Services.ExamServices;
using SchoolLessonManager.Domain.Services.LessonServices;
using SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.RegistrationServices.SchoolLessonManager.Domain.Services.RegistrationServices;
using SchoolLessonManager.Domain.Services.StudentServices;
using SchoolLessonManager.Domain.Services.TeacherServices;
using SchoolLessonManager.Domain.UnitOfWorks;

namespace SchoolLessonManager.Presentation.Extensions
{
    public static class ServiceRegistration
    {
        public static void
       AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ILessonRegistrationService, LessonRegistrationService>();
            services.AddScoped<IStudentRegistrationService, StudentRegistrationService>();
            services.AddScoped<IExamRegistrationService, ExamRegistrationService>();
        }
    }
}
