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
using System.Text.Json;
using System.Threading.Tasks;

namespace EvimiKur.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class OrderController : Controller
    {
        private readonly IAppUserService _appUserService;

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;


        public OrderController(IAppUserService appUserService, IHttpContextAccessor contextAccessor, ICartService cartService, IProductService productService, IOrderService orderService)
        {
            _appUserService = appUserService;
            _contextAccessor = contextAccessor;
            _cartService = cartService;
            _productService = productService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            if (_cartService.List() == null)
            {
                return Redirect("~/Member/Home/Index");
            }
            var cart = _cartService.List();
            var order = new OrderCreateDto();
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);


            if (userResponse.ResponseType == Common.ResponseType.Success)
            {
                order.AppUserId = userResponse.Data.Id;
                //order.AppUser = userResponse.Data;

            }
            

            foreach (var item in _cartService.List())
            {
                 
                var response = await _productService.GetByIdAsync<Product>(item.Id);
                if (response.ResponseType == ResponseType.Success)
                {
                    var product = response.Data;

                    order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                    });
                }
            }
            
            
            await _orderService.CreateAsync(order);

            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet" + userId);

            foreach (var item in _cartService.List())
            {
                var productToRemove = productList.FirstOrDefault(p => p.Id == item.Id);

                productList.Remove(productToRemove);
                _contextAccessor.HttpContext.Response.SetObject("sepet" + userId, productList);

            }
            return Redirect("~/Home/Index");
        }

    }
}
