using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Address : BaseEntity
    {
        public string AddressName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string AddressDetail { get; set; }
        public string Country { get; set; }

        //Relational Property
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}
