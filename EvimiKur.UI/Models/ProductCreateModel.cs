using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Base;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvimiKur.UI.Models
{
    public class ProductCreateModel
    {
       
        
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public decimal UnitInStock { get; set; }
        public bool Status { get; set; }
        public bool Discontinued { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
        public int DealerId { get; set; }
        public SelectList Dealer { get; set; }
        public int CategoryId { get; set; }
        public SelectList Category { get; set; }

    }
}
