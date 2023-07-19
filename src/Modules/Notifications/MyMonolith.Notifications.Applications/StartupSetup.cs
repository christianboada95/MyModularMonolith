using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyMonolith.Notifications.Application
{
    public static class StartupSetup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Aservices.AddScoped<IInventoryService, InventoryService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}