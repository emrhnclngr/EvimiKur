using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos.OrderDetailDtos
{
    public class OrderDetailListDto :IDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int AddressId { get; set; }
        public List<ProductListDto> Products { get; set; }
    }
}
