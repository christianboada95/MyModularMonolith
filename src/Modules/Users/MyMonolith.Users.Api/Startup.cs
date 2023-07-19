using MyMonolith.Users.Api;
using MyMonolith.Users.Application;
using MyMonolith.Users.Infrastructure;

namespace MyMonolith.Users
{
    public class Startup : IStartup
    {
        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}/Users")
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .Build();

            using var scope = services.BuildServiceProvider();
            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices();
            services.AddApiServices(configuration);

            return scope;
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app)
        {
            //app.UseSwaggerMiddleware(app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>());
            app.UseEndpoints(endpoints =>
                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response.WriteAsync("Hello World from Users Module");
                    })//.RequireAuthorization()
            );

        }
    }

}