using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMonolith.Users.Application.Interfaces;
using Refit;

namespace MyMonolith.Users.Infrastructure;

public static class StartupSetup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        // RefitClients
        services.AddRefitClient<IPlaceHolderClient>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                });

        return services;
    }
}