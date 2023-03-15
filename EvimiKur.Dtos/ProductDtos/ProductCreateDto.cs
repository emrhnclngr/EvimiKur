using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Dtos.ProductStatusDto;
using EvimiKur.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvimiKur.Dtos
{
    public class ProductCreateDto : IDto
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public bool Status { get; set; }
        public int UnitInStock { get; set; }
        public int UnitsInOrder { get; set; }
        public bool Discontinued { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int ProductStatusId { get; set; }
        public ProductStatusListDto ProductStatus { get; set; }
        public CategoryListDto Category { get; set; }



    }
}
