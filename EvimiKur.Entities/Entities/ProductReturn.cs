using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class ProductReturn : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        //Relational Property

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
