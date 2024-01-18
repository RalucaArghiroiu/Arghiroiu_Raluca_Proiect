namespace Arghiroiu_Raluca_Proiect.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string? Plate { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        public string? Status { get; set; }

        public int? FleetId { get; set; }
        public Fleet? Fleet { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        public ICollection<VehicleDocument>? VehicleDocuments { get; set; }
    }
}
