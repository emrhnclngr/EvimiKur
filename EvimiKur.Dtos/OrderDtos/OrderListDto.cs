using EvimiKur.Dtos.Interfaces;
using EvimiKur.Dtos.OrderDetailDtos;
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
        public bool Confirmed { get; set; }
        public int Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductListDto> Products { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        




    }
}
