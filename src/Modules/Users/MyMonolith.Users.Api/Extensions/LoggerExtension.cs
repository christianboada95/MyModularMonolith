using Microsoft.ApplicationInsights.Extensibility;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace MyMonolith.Users.Api.Extensions
{
    internal static class LoggerExtension
    {
        internal static void SetupLoggerConfiguration(string appName)
        {
            Log.Logger = new LoggerConfiguration()
                .ConfigureBaseLogging(appName)
                .CreateLogger();
        }

        internal static LoggerConfiguration ConfigureBaseLogging(
            this LoggerConfiguration loggerConfiguration,
            string appName
        )
        {
            loggerConfiguration
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", appName);

            return loggerConfiguration;
        }

        internal static LoggerConfiguration AddApplicationInsightsLogging(this LoggerConfiguration loggerConfiguration, IServiceProvider services)
        {
            loggerConfiguration.WriteTo.ApplicationInsights(
                services.GetRequiredService<TelemetryConfiguration>(),
                TelemetryConverter.Traces);

            return loggerConfiguration;
        }
    }
}
