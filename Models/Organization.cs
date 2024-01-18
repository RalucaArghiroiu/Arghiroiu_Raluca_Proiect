namespace Arghiroiu_Raluca_Proiect.Models
{
    public class Organization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Fleet>? Fleets { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
