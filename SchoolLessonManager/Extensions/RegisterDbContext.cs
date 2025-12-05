using Microsoft.EntityFrameworkCore;
using SchoolLessonManager.DataAccess.DbContexts;

namespace SchoolLessonManager.Presentation.Extensions
{
    public static class RegisterDbContext
    {
        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SchoolLessonManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}
