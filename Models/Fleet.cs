namespace Arghiroiu_Raluca_Proiect.Models
{
    public class Fleet
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
