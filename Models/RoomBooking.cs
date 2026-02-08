using System.ComponentModel.DataAnnotations;

namespace ManajemenRuangan.Models
{
    public class RoomBooking
    {
        public int Id { get; set; }

        [Required]
        public string RoomName { get; set; } = "";

        [Required]
        public string BorrowerName { get; set; } = "";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Purpose { get; set; } = "";

        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}