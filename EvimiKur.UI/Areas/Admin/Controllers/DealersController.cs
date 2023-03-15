using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DealersController : Controller
    {
        private readonly IProductService _productService;

        public DealersController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> List()
        {
            //var products = await _productService.GetAllAsync();
            var products = await _productService.GetList(StatusType.Active);
            return View(products);
            //return this.ResponseView(products);
        }
    }
}
