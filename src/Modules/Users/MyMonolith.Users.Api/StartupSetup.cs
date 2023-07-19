using MyMonolith.Users.Api.Extensions;
using System.Text.Json.Serialization;

namespace MyMonolith.Users.Api;

public static class StartupSetup
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAppInsights(config);

        // Security
        //services.AddSecurityConfiguration();

        // Cache
        services.AddMemoryCache();

        // Http
        services.AddHttpClient();

        services.AddControllers()
            .ConfigureApiBehaviorOptions(op => op.SuppressModelStateInvalidFilter = true)
            .AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfiguration();
        //services.AddHealthCheck(config);

        return services;
    }

    public static void AddAppInsights(this IServiceCollection services, IConfiguration config) =>
        services.AddApplicationInsightsTelemetry(op => //new ApplicationInsightsServiceOptions()
        {
            op.ConnectionString = config.GetConnectionString("AppInsights");
        });
}
