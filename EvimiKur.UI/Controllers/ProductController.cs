using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.DataAccess.Context;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
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
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;




        public ProductController(IUow uow, ICategoryService categoryService, EvimiKurContext context, IProductService productService, IMapper mapper)
        {
            _uow = uow;
            _categoryService = categoryService;
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListActiveProduct();
           
            return View(products);
        }

        public async Task<IActionResult> List(string query)
        {


            var products = await _uow.GetRepository<Product>().GetFilteredList(

                //TODO:ProductListDto yerine ProductListModel dönülecek.
                select: x => new ProductListDto
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
                where: (x => x.ProductName.Contains(query.ToUpper().Trim())),
                orderyBy: x => x.OrderByDescending(x => x.CreatedDate),
                join: x => x.Include(x => x.Category));
          
            
            
            return View(products);
        }


    }
}
