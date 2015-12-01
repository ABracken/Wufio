using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wufio.Core
{
public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public System.Data.Entity.DbSet<Wufio.Core.Domain.Animal> Animals { get; set; }

        public System.Data.Entity.DbSet<Wufio.Core.Domain.AnimalType> AnimalTypes { get; set; }

        public System.Data.Entity.DbSet<Wufio.Core.Domain.WufioUser> IdentityUsers { get; set; }

        public System.Data.Entity.DbSet<Wufio.Core.Domain.Rescue> Rescues { get; set; }

        public System.Data.Entity.DbSet<Wufio.Core.Domain.UserAnimal> UserAnimals { get; set; }
    }
}