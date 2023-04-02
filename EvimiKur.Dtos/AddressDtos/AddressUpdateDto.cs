using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class AddressUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string AddressDetail { get; set; }
        public string Country { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}
