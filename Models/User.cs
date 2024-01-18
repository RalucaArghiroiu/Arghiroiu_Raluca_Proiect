using System.ComponentModel;

namespace Arghiroiu_Raluca_Proiect.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        [DefaultValue(null)]
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
    }
}
