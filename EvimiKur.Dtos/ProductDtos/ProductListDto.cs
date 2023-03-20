using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Dtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public bool Status { get; set; }
        public bool Discontinued { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
        public Dealer Dealer { get; set; }
        public CategoryListDto Category { get; set; }
        

    }
}
