using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Product : BaseEntity
    {
        
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int UnitsInOrder { get; set; }
        public bool Discontinued { get; set; }
        public string ImagePath { get; set; }
        

        //Relational Property
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public int ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }

        //public int ProductReturnId { get; set; }
        //public ProductReturn ProductReturn { get; set; }

        //public int OrderId { get; set; }
        //public Order Order { get; set; }

    }
}
