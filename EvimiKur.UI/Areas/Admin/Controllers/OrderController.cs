using EvimiKur.Bussiness.CustomExtensions;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Common;
using EvimiKur.Common.Enums;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IActionResult> Pending()
        {

            var orders = await _orderService.GetList(Common.Enums.StatusType.Pending);

            foreach (var order in orders)
            {
                foreach (var item in order.OrderDetails)
                {
                    var response = await _productService.GetByIdAsync<Product>(item.ProductId);
                    if (response.ResponseType == ResponseType.Success)
                    {
                        var product = response.Data;
                        item.UnitPrice = (product.UnitPrice * item.Quantity);
                    }
                }

                order.Price = order.OrderDetails.Sum(x => x.UnitPrice);
            }
            return View(orders);
        }

        public async Task<IActionResult> SetStatus(int orderId, StatusType type)
        {
            await _orderService.SetStatusAsync(orderId, type);
            return RedirectToAction("Pending");
        }

        public async Task<IActionResult> Confirmed()
        {
            var orders = await _orderService.GetList(Common.Enums.StatusType.Active);

            foreach (var order in orders)
            {
                foreach (var item in order.OrderDetails)
                {
                    var response = await _productService.GetByIdAsync<Product>(item.ProductId);
                    if (response.ResponseType == ResponseType.Success)
                    {
                        var product = response.Data;

                        item.UnitPrice = (product.UnitPrice * item.Quantity);
                    }
                }
                order.Price = order.OrderDetails.Sum(x => x.UnitPrice);
            }
            return View(orders);
        }

        public async Task<IActionResult> Rejected()
        {
            var orders = await _orderService.GetList(Common.Enums.StatusType.Passive);

            foreach (var order in orders)
            {
                foreach (var item in order.OrderDetails)
                {
                    var response = await _productService.GetByIdAsync<Product>(item.ProductId);
                    if (response.ResponseType == ResponseType.Success)
                    {
                        var product = response.Data;

                        item.UnitPrice = (product.UnitPrice * item.Quantity);
                    }
                }

                order.Price = order.OrderDetails.Sum(x => x.UnitPrice);
            }
            return View(orders);

        }
    }
}
