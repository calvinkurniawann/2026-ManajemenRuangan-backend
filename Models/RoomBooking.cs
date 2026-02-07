namespace ManajemenRuangan.Models
{
    public class RoomBooking
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = "";
        public string BorrowerName { get; set; } = "";
        public DateTime Date { get; set; }
        public string Purpose { get; set; } = "";
        public string Status { get; set; } = "Pending";

    }
}