using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform is null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
        }

        public IPlatform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(platform => platform.Id == id);
        }

        public IEnumerable<IPlatform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
