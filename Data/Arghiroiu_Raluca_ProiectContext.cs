using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Arghiroiu_Raluca_Proiect.Models;

namespace Arghiroiu_Raluca_Proiect.Data
{
    public class Arghiroiu_Raluca_ProiectContext : DbContext
    {
        public Arghiroiu_Raluca_ProiectContext (DbContextOptions<Arghiroiu_Raluca_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Arghiroiu_Raluca_Proiect.Models.Organization> Organization { get; set; } = default!;

        public DbSet<Arghiroiu_Raluca_Proiect.Models.Fleet>? Fleet { get; set; }

        public DbSet<Arghiroiu_Raluca_Proiect.Models.Vehicle>? Vehicle { get; set; }

        public DbSet<Arghiroiu_Raluca_Proiect.Models.User>? User { get; set; }

        public DbSet<Arghiroiu_Raluca_Proiect.Models.Invoice>? Invoice { get; set; }

        public DbSet<Arghiroiu_Raluca_Proiect.Models.Booking>? Booking { get; set; }

        public DbSet<Arghiroiu_Raluca_Proiect.Models.VehicleDocument>? VehicleDocument { get; set; }
    }
}
