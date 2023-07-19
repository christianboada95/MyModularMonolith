using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using MyMonolith.Users.Api.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace MyMonolith.Users.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(sw =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                sw.IncludeXmlComments(xmlPath);
                //sw.EnableAnnotations();
            }).AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptions>();

            services.AddVersionedApiExplorer(op =>
            {
                op.GroupNameFormat = "'v'VVV";
                op.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(c =>
            {
                c.DefaultApiVersion = new ApiVersion(1, 0);
                c.AssumeDefaultVersionWhenUnspecified = true;
                c.ReportApiVersions = true;
            });

            return services;
        }

        public static void UseSwaggerMiddleware(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseSwaggerUI(c =>
            //{
            //    foreach (var name in provider.ApiVersionDescriptions.Select(x => x.GroupName))
            //        c.SwaggerEndpoint($"/{name}/swagger.json", $"Hola mundo - {name.ToUpperInvariant()}");
            //});
        }
    }
}

