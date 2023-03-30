﻿using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class OrderListDto : IDto
    {
        public int Id { get; set; }
        //public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
        //public DateTime ShippedDate { get; set; }
        /*public int ShipVia { get; set; }*/ // Değiştirilebilir.(İsmi ile)
        //public int Freight { get; set; }
        //public string Country { get; set; }
        //public string City { get; set; }
        //public string Region { get; set; }
        //public string Address { get; set; }
        //public string PostalCode { get; set; }
        public bool Confirmed { get; set; }
        public int Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
