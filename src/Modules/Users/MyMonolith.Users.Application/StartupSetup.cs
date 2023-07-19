using Microsoft.Extensions.DependencyInjection;

namespace MyMonolith.Users.Application;

public static class StartupSetup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Services

        // Mappings
        //services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}