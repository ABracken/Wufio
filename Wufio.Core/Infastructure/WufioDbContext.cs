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
            modelBuilder.Entity<Animal>().HasMany(a => a.UserLikes)
                                         .WithRequired(ua => ua.Animal)
                                         .HasForeignKey(ua => ua.AnimalId);   

            modelBuilder.Entity<AnimalType>().HasKey(at => at.AnimalTypeId);
            modelBuilder.Entity<AnimalType>().HasMany(at => at.Animals)
                                             .WithRequired(a => a.AnimalType)
                                             .HasForeignKey(a => a.AnimalTypeId);

            modelBuilder.Entity<Rescue>().HasKey(r => r.RescueId);
            modelBuilder.Entity<Rescue>().HasMany(r => r.Volunteers)
                                         .WithOptional(wu => wu.Rescue)
                                         .HasForeignKey(wu => wu.RescueId);

            modelBuilder.Entity<UserAnimal>().HasKey(ua => new { ua.WufioUserId, ua.AnimalId });

            modelBuilder.Entity<WufioUser>().HasMany(wu => wu.LikedAnimals)
                                            .WithRequired(ua => ua.WufioUser)
                                            .HasForeignKey(ua => ua.WufioUserId);
            modelBuilder.Entity<WufioUser>().HasMany(wu => wu.AddedAnimals)
                                            .WithRequired(a => a.Volunteer)
                                            .HasForeignKey(a => a.WufioUserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
