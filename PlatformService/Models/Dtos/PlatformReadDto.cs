using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace PlatformService.Models.Dtos
{
    public class PlatformReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}
