using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Data;
using ManajemenRuangan.Models;
using ManajemenRuangan.DTOs.RoomBookings;

namespace ManajemenRuangan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomBookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomBookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? room,
            [FromQuery] string? borrower,
            [FromQuery] BookingStatus? status)
        {
            var query = _context.RoomBookings
                .Include(b => b.Room)
                .AsQueryable();

            if (!string.IsNullOrEmpty(room))
                query = query.Where(b => b.Room.Name.Contains(room));

            if (!string.IsNullOrEmpty(borrower))
                query = query.Where(b => b.BorrowerName.Contains(borrower));

            if (status.HasValue)
                query = query.Where(b => b.Status == status.Value);

            var result = await query
                .Select(b => new RoomBookingResponseDto
                {
                    id = b.Id,
                    RoomName = b.Room.Name,
                    BorrowerName = b.BorrowerName,
                    Date = b.Date,
                    Purpose = b.Purpose,
                    Status = b.Status
                })
                .ToListAsync();

            return Ok(result);
        }



        // GET: api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _context.RoomBookings
                .Include(b => b.Room)
                .Where(b => b.Id == id)
                .Select(b => new RoomBookingResponseDto
                {
                    id = b.Id,
                    RoomName = b.Room.Name,
                    BorrowerName = b.BorrowerName,
                    Date = b.Date,
                    Purpose = b.Purpose,
                    Status = b.Status
                })
                .FirstOrDefaultAsync();
            if (booking == null)
            {
                return NotFound(new { Message = "Data tidak ditemukan" });
            }
            return Ok(booking);
        }



        // POST: api/bookings
        [HttpPost]
        public async Task<IActionResult> Create(RoomBookingCreateDto dto)
        {
            var roomExists = await _context.Rooms.AnyAsync(r => r.id == dto.RoomId);
            if (!roomExists)
                return BadRequest(new { Message = "Room tidak ditemukan" });

            var isConflict = await _context.RoomBookings
            .AnyAsync(b =>
                b.RoomId == dto.RoomId &&
                b.Date.Date == dto.Date.Date &&
                b.Status == BookingStatus.Approved
            );

            if (isConflict)
            {
                return BadRequest(new
                {
                    Message = "Ruangan sudah dibooking dan disetujui pada tanggal tersebut"
                });
            }

            var booking = new RoomBooking
            {
                RoomId = dto.RoomId,
                BorrowerName = dto.BorrowerName,
                Date = dto.Date,
                Purpose = dto.Purpose,
                Status = BookingStatus.Pending
            };

            _context.RoomBookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        // PUT: api/bookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomBookingUpdateDto dto)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null)
                return NotFound();

            if (booking.Status != BookingStatus.Pending)
            {
                return BadRequest(new
                {
                    Message = "Tidak bisa mengubah data yang sudah diproses"
                });
            }

            var isConflict = await _context.RoomBookings
            .AnyAsync(b =>
                b.Id != id &&
                b.RoomId == dto.RoomId &&
                b.Date.Date == dto.Date.Date &&
                b.Status == BookingStatus.Approved
            );

            if (isConflict)
            {
                return BadRequest(new
                {
                    Message = "Ruangan sudah dibooking dan disetujui pada tanggal tersebut"
                });
            }

            var roomExists = await _context.Rooms.AnyAsync(r => r.id == dto.RoomId);
            if (!roomExists)
            {
                return BadRequest(new
                {
                    Message = "Room tidak ditemukan"
                });
            }

            booking.RoomId = dto.RoomId;
            booking.BorrowerName = dto.BorrowerName;
            booking.Date = dto.Date;
            booking.Purpose = dto.Purpose;

            await _context.SaveChangesAsync();

            return Ok(booking);
        }




        //PUT api/bookings/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] BookingStatus status)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = status;
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        // DELETE: api/bookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}