using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Models;

namespace ManajemenRuangan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RoomBooking> RoomBookings { get; set; }
    }
}

