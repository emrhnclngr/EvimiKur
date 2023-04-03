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
        public OrderCreateDto()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public bool Confirmed { get; set; }
        public int AppUserId { get; set; }
        public int Status { get; set; }
        public AppUserListDto AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        


    }
}
