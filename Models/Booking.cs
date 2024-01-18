namespace Arghiroiu_Raluca_Proiect.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string? Status { get; set; }
    }
}
