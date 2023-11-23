using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Extensions
{
    public static class StartupExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IPlatformRepo, PlatformRepo>();
            services.AddScoped<IPlatform, Platform>();
        }
    }
}
