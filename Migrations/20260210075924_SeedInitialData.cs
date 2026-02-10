using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026_ManajemenRuangan_backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "RoomBookings");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Rooms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomBookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Gedung D4 Lantai 2", "Ruang A203" },
                    { 2, "Gedung D3 Lantai 1", "Ruang HH-104" },
                    { 3, "Gedung D4 Lantai 3", "Lab Jaringan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomBookings");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "RoomBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
