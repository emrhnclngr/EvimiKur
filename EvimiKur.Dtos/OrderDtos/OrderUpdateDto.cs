using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class OrderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public bool Confirmed { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        

    }
}
