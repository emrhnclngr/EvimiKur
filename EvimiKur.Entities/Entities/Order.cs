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
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
        //public DateTime ShippedDate { get; set; } ileriki zamanlarda düşünülür....
        public int ShipVia { get; set; } // Değiştirilebilir.(İsmi ile)
        public int Freight { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public bool Confirmed { get; set; }

        //Relational Property
        public List<ProductReturn> ProductReturns { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int SupplierId { get; set; }   
        public Supplier Supplier  { get; set; } // bunu düzenle ne alaka !!!!!!  (Dealer olabilir)

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
