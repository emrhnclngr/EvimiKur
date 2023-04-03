using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class SubCategory : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        //Relational Property
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
