using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Dealer : BaseEntity
    {
        public string Name { get; set; }
        public string  Description { get; set; }
        public string Address { get; set; }
        public string Responsible { get; set; }
        public string PhoneNumber { get; set; }


        public List<Product> Products { get; set; }
    }
}
