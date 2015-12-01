using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wufio.Core.Models
{
    public class UserAnimalModel
    {
        public int AnimalId { get; set; }
        public int AnimalTypeId { get; set; }
        public string WufioUserId { get; set; }
        public bool Liked { get; set; }
    }
}
