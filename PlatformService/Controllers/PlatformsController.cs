using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Extensions;
using PlatformService.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace PlatformService.Controllers
{
    [Route("api/Platforms")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly ILogger _logger;
        public PlatformsController(IPlatformRepo platformRepo, ILogger<PlatformsController> logger)
        {
            _platformRepo = platformRepo;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            _logger.LogInformation("Запрос в метод api/Platforms/getAll");

            var platforms = _platformRepo.GetAllPlatforms();
            if (platforms == null)
            {
                return NotFound();

            }
            return Ok(platforms.Select(platform => platform.CreateFromPlatform()));
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<PlatformReadDto> GetPlatform(int id)
        {
            _logger.LogInformation("Запрос в метод api/Platforms/getAll");

            var platform = _platformRepo.GetPlatformById(id).CreateFromPlatform();
            if (platform == null)
            {
                return NotFound();

            }
            return Ok(platform);
        }

        [Route("create")]
        [HttpPost]
        public ActionResult<PlatformReadDto> Create(PlatformCreateDto createModel)
        {
            _logger.LogInformation("Запрос в метод api/Platforms/getAll");
            try
            {
                var newId = _platformRepo.CreatePlatform(createModel.CreateFromDto());
                var platform = _platformRepo.GetPlatformById(newId).CreateFromPlatform();
                _platformRepo.SaveChanges();
                return Ok(platform);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в методе api/Platforms/create");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
