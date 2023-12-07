using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformService.Models
{
    public class Platform : IPlatform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }

        public Platform() { }
        public Platform(string name, string publisher, string cost)
        {
            Name = name;
            Publisher = publisher;
            Cost = cost;
        }
    }
}
