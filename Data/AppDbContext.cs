using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Models;

namespace ManajemenRuangan.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomBooking>()
                .HasOne(rb => rb.Room)
                .WithMany(r => r.RoomBookings)
                .HasForeignKey(rb => rb.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}

