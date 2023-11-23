using PlatformService.Models.Dtos;
using PlatformService.Models;

namespace PlatformService.Extensions
{
    public static class PlatformExtensions
    {
        public static Platform CreateFromDto(this PlatformCreateDto model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Platform()
            {
                Name = model.Name,
                Publisher = model.Publisher,
                Cost = model.Cost
            };
        }

        public static PlatformReadDto CreateFromPlatform(this IPlatform model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new PlatformReadDto
            {
                Id = model.Id,
                Name = model.Name,
                Publisher = model.Publisher,
                Cost = model.Cost
            };
        }

    }
}
