using System.ComponentModel.DataAnnotations;

namespace ManajemenRuangan.DTOs.RoomBookings;

public class RoomBookingUpdateDto
{
    [Required]
    public int RoomId { get; set; }

    [Required]
    public string BorrowerName { get; set; } = null!;

    [Required]
    public DateTime Date { get; set; }

    public string Purpose { get; set; } = null!;
}
