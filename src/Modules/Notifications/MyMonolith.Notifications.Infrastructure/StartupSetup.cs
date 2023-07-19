using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMonolith.Notifications.Application.Interfaces;
using MyMonolith.Notifications.Infrastructure.Data;
using MyMonolith.Notifications.Infrastructure.Repositories;

namespace MyMonolith.Notifications.Infrastructure
{
    public static class StartupSetup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            // SQL Server
            //services.AddDbContext(config.GetConnectionString("SqlServer")!);
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("NotificationsDB"));

            #region Repositories
            services.AddScoped<INotificationRepository, NotificationRepository>();
            #endregion

            return services;
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
    }
}