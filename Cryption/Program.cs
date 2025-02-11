using Cryption.services;
using Microsoft.OpenApi.Models;

namespace Cryption
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            
            builder.Services.AddScoped<crypticservices>();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "omers api", Version = "v1" });
            });

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "omers api");
                options.RoutePrefix = string.Empty;
            });

            app.MapControllers();
            app.Run();
        }
    }
}