namespace SchoolLessonManager.Presentation.Extensions
{
    public static class MainExtension
    {
        public static void AddMainExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddServices();
        }
    }
}
