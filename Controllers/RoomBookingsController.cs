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

        // POST: api/bookings
        [HttpPost]
        public async Task<IActionResult> Create(RoomBooking booking)
        {
            _context.RoomBookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }
    }
}