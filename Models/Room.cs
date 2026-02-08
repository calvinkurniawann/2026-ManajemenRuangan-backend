using System.ComponentModel.DataAnnotations;

namespace ManajemenRuangan.Models
{
    public class Room
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Location { get; set; } = "";
    }
}