using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace API_Galkin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Руководство для пользования запросов",
                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "Руководство для пользования запросов",
                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                c.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v3",
                    Title = "Руководство для пользования запросов",
                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                c.SwaggerDoc("v4", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v4",
                    Title = "Руководство для пользования запросов",
                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "API_Galkin.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "Запросы PUT");
                c.SwaggerEndpoint("/swagger/v4/swagger.json", "Запросы DELETE");
            });
        }
    }
}
