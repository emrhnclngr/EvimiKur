using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class OrderCreateDto : IDto
    {

        public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
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
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int SupplierId { get; set; }
    }
}
