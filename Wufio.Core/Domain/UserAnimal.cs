using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wufio.Core.Domain
{
    public class UserAnimal
    {
        public int UserAnimalId { get; set; }
        public int AnimalId { get; set; }
        public int AnimalTypeId { get; set; }
        public string WufioUserId { get; set; }
        public bool Liked { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual AnimalType AnimalType { get; set; }
        public virtual ICollection<WufioUser> WufioUsers { get; set; }
    }
}
