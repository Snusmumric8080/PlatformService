using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<IPlatform> GetAllPlatforms();
        IPlatform GetPlatformById(int id);
        int CreatePlatform(Platform platform);
    }
}
