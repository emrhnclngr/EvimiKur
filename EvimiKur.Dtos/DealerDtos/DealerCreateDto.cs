using EvimiKur.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class DealerCreateDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Responsible { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
