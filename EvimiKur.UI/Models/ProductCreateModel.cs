using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Base;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvimiKur.UI.Models
{
    public class ProductCreateModel 
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
        public SelectList ProductStatus { get; set; }
        public SelectList Category { get; set; }
    }
}
