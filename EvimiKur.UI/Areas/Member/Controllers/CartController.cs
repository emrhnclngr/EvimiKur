﻿using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult List()
        {
            return View(_cartService.List());
        }
       
        public async Task<IActionResult> AddCart(int id)
        {
            
            var response = await _productService.GetByIdAsync<ProductListDto>(id);
            if (response.ResponseType == ResponseType.Success)
            {

                var product = response.Data;
                _cartService.Add(product);
                TempData["info"] = "Product Add to Cart";
            }
            else
            {
                TempData["info"] = response.Message;
            }
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Remove(int id)
        {
            _cartService.Remove(id);
            return RedirectToAction("List","Cart");
        }

        public IActionResult IncreaseProductQuantity(int id)
        {
            _cartService.IncreaseCartCookie(id);
            var productList = _cartService.List();
            return RedirectToAction("List", "Cart");
        }
        public IActionResult DecreaseProductQuantity(int id)
        {
            _cartService.DecreaseCartCookie(id);
            var productList = _cartService.List();
            return RedirectToAction("List", "Cart");
        }


    }
}
