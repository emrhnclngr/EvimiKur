using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Category : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        //Relational Property
        
        public List<Product> Products { get; set; }

        public List<SubCategory> SubCategories  { get; set; }
    }
}
