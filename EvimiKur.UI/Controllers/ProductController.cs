using EvimiKur.Bussiness.Interfaces;
using EvimiKur.DataAccess.Context;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Entities.Entities;
using EvimiKur.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EvimiKur.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUow _uow;
        private readonly ICategoryService _categoryService;
       

        public ProductController(IUow uow, ICategoryService categoryService, EvimiKurContext context)
        {
            _uow = uow;
            _categoryService = categoryService;
            
        }

        public async Task<IActionResult> List(string query)
        {


            var products = await _uow.GetRepository<Product>().GetFilteredList(
                select: x => new ProductListModel
                {
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    UnitInStock = x.UnitInStock,
                    UnitPrice = x.UnitPrice,
                    Status = x.Status,
                    Discontinued = x.Discontinued,
                    Image = x.Image,
                    UploadImage = x.UploadImage,
                },
                where: x => x.ProductName.Contains(query.ToUpper()),
                orderyBy: x => x.OrderByDescending(x => x.CreatedDate),
                join: x => x.Include(x => x.Category)); ;
            return View(products);
        }


    }
}
