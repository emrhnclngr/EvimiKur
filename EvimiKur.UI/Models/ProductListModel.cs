using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvimiKur.UI.Models
{
    public class ProductListModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public bool Status { get; set; }
        public bool ShowroomType { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }

    }
}
