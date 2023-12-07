using PlatformService.Data;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Extensions
{
    public static class StartupExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IPlatformRepo, PlatformRepo>();
            services.AddScoped<IPlatform, Platform>();
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
        }
    }
}
