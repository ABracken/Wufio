using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wufio.Core.Models
{
    class AnimalModel
    {
        public int AnimalId { get; set; }
        public int AnimalTypeId { get; set; }
        public string WufioUserId { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public string ImageUrl { get; set; }
        public string Notes { get; set; }

    }
}
