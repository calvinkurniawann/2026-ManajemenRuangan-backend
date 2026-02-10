using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Models;

namespace ManajemenRuangan.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomBooking>()
                .HasOne(rb => rb.Room)
                .WithMany(r => r.RoomBookings)
                .HasForeignKey(rb => rb.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    id = 1,
                    Name = "Ruang A203",
                    Location = "Gedung D4 Lantai 2"
                },
                new Room
                {
                    id = 2,
                    Name = "Ruang HH-104",
                    Location = "Gedung D3 Lantai 1"
                },
                new Room
                {
                    id = 3,
                    Name = "Lab Jaringan",
                    Location = "Gedung D4 Lantai 3"
                }
            );
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}

