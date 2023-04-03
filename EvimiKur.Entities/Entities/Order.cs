using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        
        public bool Confirmed { get; set; }


        //Relational Property
        public List<ProductReturn> ProductReturns { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        

    }
}
