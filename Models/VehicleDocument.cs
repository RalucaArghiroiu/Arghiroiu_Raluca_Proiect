using System.ComponentModel.DataAnnotations;

namespace Arghiroiu_Raluca_Proiect.Models
{
    public class VehicleDocument
    {
        public int Id { get; set; }

        public string Type { get; set; }

        [Display(Name = "Expires at")]
        public DateTime ExpirationDate { get; set; }

        public string? Status { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
