using EvimiKur.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos.ProductReturnDtos
{
    public class ProductReturnListDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
