using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026_ManajemenRuangan_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteToRoomBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RoomBookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RoomBookings");
        }
    }
}
