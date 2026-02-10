using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Data;
using ManajemenRuangan.Models;
using ManajemenRuangan.DTOs.Rooms;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/rooms
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _context.Rooms
            .Select(r => new RoomResponseDto
            {
                id = r.id,
                Name = r.Name,
                Location = r.Location
            })
            .ToListAsync();
        
        return Ok(rooms);
    }

    // POST: api/rooms
    [HttpPost]
    public async Task<IActionResult> Create(RoomCreateDto dto)
    {
        var room = new Room
        {
            Name = dto.Name,
            Location = dto.Location
        };

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = room.id }, room);
    }

    // PUT: api/rooms/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RoomUpdateDto dto)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();

        room.Name = dto.Name;
        room.Location = dto.Location;

        await _context.SaveChangesAsync();
        return Ok(room);
    }

    // DELETE: api/rooms/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound(new { Message = "Data tidak ditemukan" });
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}