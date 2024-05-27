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
                    Title = "����������� ��� ����������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                });
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "����������� ��� ����������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� GET");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� POST");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� PUT");
            });
        }
    }
}
