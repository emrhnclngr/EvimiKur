using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class ProductStatus : BaseEntity
    {
        public string Definition { get; set; }

        public List<Product> Products { get; set; }
    }
}
