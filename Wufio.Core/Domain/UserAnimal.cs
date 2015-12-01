using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wufio.Core.Models;

namespace Wufio.Core.Domain
{
    public class UserAnimal
    {
        public int AnimalId { get; set; }
        public string WufioUserId { get; set; }
        public bool Liked { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual WufioUser WufioUser { get; set; }

        public void Update(UserAnimalModel userAnimal)
        {            
            AnimalId = userAnimal.AnimalId;
            WufioUserId = userAnimal.WufioUserId;
            Liked = userAnimal.Liked;
        }
    }
}
