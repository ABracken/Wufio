using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wufio.Core.Models;

namespace Wufio.Core.Domain
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public int AnimalTypeId { get; set; }
        public string WufioUserId { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public string ImageUrl { get; set; }
        public string Notes { get; set; }

        public virtual AnimalType AnimalType { get; set; }
        public virtual WufioUser Volunteer { get; set; }

        public void Update(AnimalModel animal)
        {
            AnimalId = animal.AnimalId;
            AnimalTypeId = animal.AnimalTypeId;
            WufioUserId = animal.WufioUserId;
            Age = animal.Age;
            Gender = animal.Gender;
            Breed = animal.Breed;
            ImageUrl = animal.ImageUrl;
            Notes = animal.Notes;
        }
    }
}
