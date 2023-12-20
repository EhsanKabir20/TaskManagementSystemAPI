using Microsoft.Extensions.DependencyInjection.Extensions;
namespace TaskManagementSystem.Data.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTMSServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILogService, LogService>();
            return services;
        }
    }
}
