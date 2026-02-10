using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManajemenRuangan.Models
{
        public class RoomBooking
        {
                public int Id { get; set; }

                [Required]
                public int RoomId { get; set; } 

                [JsonIgnore]
                public Room Room { get; set; } = null!;

                [Required]
                public string BorrowerName { get; set; } = "";

                [Required]
                public DateTime Date { get; set; }

                [Required]
                public string Purpose { get; set; } = "";

                public BookingStatus Status { get; set; } = BookingStatus.Pending;

                public bool IsDeleted { get; set; } = false;
        }
}