using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManajemenRuangan.Models
{
    public class Room
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        [JsonIgnore]
        public ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
    }

}