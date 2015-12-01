using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wufio.Core.Domain;

namespace Wufio.Core.Infastructure
{
    public class WufioDbContext : IdentityDbContext<WufioUser>
    {
        public IDbSet<Animal> Animals { get; set; }
        public IDbSet<AnimalType> AnimalTypes { get; set; }
        public IDbSet<Rescue> Rescues { get; set; }
        public IDbSet<UserAnimal> UserAnimals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasKey(a => a.AnimalId);

            modelBuilder.Entity<AnimalType>().HasKey(at => at.AnimalTypeId);

            modelBuilder.Entity<Rescue>().HasKey(r => r.RescueId);

            modelBuilder.Entity<UserAnimal>().HasKey(ua => new { ua.WufioUserId, ua.AnimalId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
