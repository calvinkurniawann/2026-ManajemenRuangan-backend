using ManajemenRuangan.Models;

namespace ManajemenRuangan.DTOs.RoomBookings;

public class RoomBookingResponseDto
{
    public int id { get; set; }
    public string RoomName { get; set; } = null!;
    public string BorrowerName { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Purpose { get; set; } = null!;
    public BookingStatus Status { get; set; }
}
