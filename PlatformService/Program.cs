using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Extensions;
using Serilog;

namespace PlatformService
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            //OpenApi
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Microservice",
                    Version = "v1",
                    Description = "Main Platform"
                });
            });

            //Логи
            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            Log.Logger = new LoggerConfiguration()
             .WriteTo.Http(
                 queueLimitBytes: 100_000_000,
                 requestUri: "http://logstash:5044",
                 textFormatter: new Serilog.Formatting.Json.JsonFormatter(),
                 batchFormatter: new Serilog.Sinks.Http.BatchFormatters.ArrayBatchFormatter())
             .CreateLogger();

            //Биндинг
            builder.Services.AddScopedServices();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });
            app.UseSerilogRequestLogging();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();


        }
    }
}