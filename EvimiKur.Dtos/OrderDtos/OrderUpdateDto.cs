using EvimiKur.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos.OrderDtos
{
    public class OrderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; } // Değiştirilebilir.(İsmi ile)
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPostalCode { get; set; }
        public bool Confirmed { get; set; }
    }
}
