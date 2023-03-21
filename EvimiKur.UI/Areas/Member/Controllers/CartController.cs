using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EvimiKur.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(IProductService productService, ICartService cartService, IMapper mapper)
        {
            _productService = productService;
            _cartService = cartService;
            _mapper = mapper;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            return View(_cartService.ProductInTheCart());
        }
        public async Task<IActionResult> AddCart(int id)
        {
            var response = await _productService.GetByIdAsync<ProductListDto>(id);
            if (response.ResponseType == ResponseType.Success)
            {
                var product = response.Data;
                _cartService.AddToCart(product);
                TempData["info"] = "Product Add to Cart";
                
            }
            else
            {
                TempData["info"] = response.Message;
            }
            return View("Index");
        }
    }
}
