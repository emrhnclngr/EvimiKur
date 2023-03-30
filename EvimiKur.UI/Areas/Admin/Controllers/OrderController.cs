using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Pending()
        {
            

            var list = await _orderService.GetList(Common.Enums.StatusType.Pending);

            return View(list);
        }
    }
}
