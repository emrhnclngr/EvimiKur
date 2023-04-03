using EvimiKur.Entities.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Entities.Entities
{
    public class Product : BaseEntity
    {

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int UnitsInOrder { get; set; }
        public bool ShowroomType { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public IFormFile UploadImage { get; set; }


        //Relational Property
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
