using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wufio.Core.Models;

namespace Wufio.Core.Domain
{
    public class AnimalType
    {  
        public int AnimalTypeId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

        public void Update(AnimalTypeModel animalType)
        {
            AnimalTypeId = animalType.AnimalTypeId;
            Description = animalType.Description;
            ImageUrl = animalType.ImageUrl;
        }
    }
}
