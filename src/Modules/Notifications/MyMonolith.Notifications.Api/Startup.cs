using MyMonolith.Notifications.Application;
using MyMonolith.Notifications.Infrastructure;

namespace MyMonolith.Notifications
{
    public class Startup : IStartup
    {
        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}/Notifications")
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true)
                .Build();

            using var scope = services.BuildServiceProvider();
            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices();
            //services.AddApiServices(Configuration);

            return scope;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response.WriteAsync("Hello World from Notifications Module");
                    })
            );

        }
    }

}