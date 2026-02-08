using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Data;
using ManajemenRuangan.Models;

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
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.RoomBookings.ToListAsync();
            return Ok(data);
        }

        // GET: api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound(new { Message = "Data tidak ditemukan" });
            }
            return Ok(booking);
        }



        // POST: api/bookings
        [HttpPost]
        public async Task<IActionResult> Create(RoomBooking booking)
        {
            booking.Status = BookingStatus.Pending;

            _context.RoomBookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        // PUT: api/bookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomBooking updated)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            if (booking.Status != BookingStatus.Pending)
            {
                return BadRequest(new { Message = "Tidak bisa mengubah data yang sudah diproses" });
            }

            booking.RoomName = updated.RoomName;
            booking.BorrowerName = updated.BorrowerName;
            booking.Date = updated.Date;
            booking.Purpose = updated.Purpose;
            booking.Status = updated.Status;

            await _context.SaveChangesAsync();

            return Ok(booking);
        }



        //PUT api/bookings/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult>UpdateStatus(int id, [FromBody] BookingStatus status)
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

            _context.RoomBookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}