using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyMonolith.Host;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers().ConfigureApplicationPartManager(manager =>
        {
            // Clear all auto detected controllers.
            manager.ApplicationParts.Clear();

            // Add feature provider to allow "internal" controller
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });

        // Register a convention allowing to us to prefix routes to modules.
        builder.Services.AddTransient<IPostConfigureOptions<MvcOptions>, ModuleRoutingMvcOptionsPostConfigure>();

        // Register Modules Services
        builder.Services.AddModule<MyMonolith.Users.Startup>("Users");
        builder.Services.AddModule<MyMonolith.Notifications.Startup>("Notifications");

        builder.Host.UseSerilog((_, services, config) =>
        {

        });

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        Configure(app, builder.Environment);
    }

    public static void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        // Adds endpoints defined in modules
        var modules = app.Services.GetRequiredService<IEnumerable<Module>>();
        foreach (var module in modules)
        {
            app.Map($"/{module.RoutePrefix}", builder =>
            {
                builder.UseRouting();
                module.Startup.Configure(builder);
            });
        }

        app.Run();
    }
}