using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Common.Enums;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DealerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDealerService _dealerService;

        public DealerController(IProductService productService, IDealerService dealerService)
        {
            _productService = productService;
            _dealerService = dealerService;
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DealerCreateDto dto)
        {

            var response = await _dealerService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }

        public async Task<IActionResult> List()
        {
            
            var dealers = await _productService.GetList(StatusType.Active);
            return View(dealers);
            
        }

    }
}
