using EvimiKur.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos.SubCategoryDtos
{
    public class SubCategoryUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
