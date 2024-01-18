using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arghiroiu_Raluca_Proiect.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string? Number { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Cost { get; set; }

        public string? Currency { get; set; }

        [Display(Name = "Issued at")]
        public DateTime IssuedAt { get; set; }

        [Display(Name = "Due date")]
        public DateTime DueDate { get; set; }

        public string? Status { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
