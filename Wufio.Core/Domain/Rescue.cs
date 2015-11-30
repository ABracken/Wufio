using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wufio.Core.Models;

namespace Wufio.Core.Domain
{
    public class Rescue
    {
        public int RescueId { get; set; }
        public string RescueName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string NonProfitLink { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<WufioUser> Volunteers { get; set; }

        public void Update(RescueModel rescue)
        {
            throw new NotImplementedException();
        }
    }
}
