using System.ComponentModel.DataAnnotations;

namespace ManajemenRuangan.DTOs.Rooms;

public class RoomCreateDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Location { get; set; } = null!;
}
