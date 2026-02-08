using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Data;
using ManajemenRuangan.Models;

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
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms);
    }

    // GET: api/rooms/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound(new { Message = "Data tidak ditemukan" });
        }
        return Ok(room);
    }

    // POST: api/rooms
    [HttpPost]
    public async Task<IActionResult> Create(Room room)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = room.id }, room);
    }

    // PUT: api/rooms/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Room room)
    {
        if (id != room.id)
        {
            return BadRequest(new { Message = "ID tidak sesuai" });
        }

        _context.Entry(room).State = EntityState.Modified;
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