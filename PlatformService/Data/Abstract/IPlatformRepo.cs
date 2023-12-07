using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<IPlatform> GetAllPlatforms();
        IPlatform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}
