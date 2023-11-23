using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Platform : IPlatform
    {
        [Key]
        [Required]
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
