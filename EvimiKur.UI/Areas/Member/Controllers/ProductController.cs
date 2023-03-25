using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ProductController(IProductService productService, ICartService cartService, IMapper mapper, IUow uow)
        {
            _productService = productService;
            _cartService = cartService;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListActiveProduct();
            return View(products);
        }
       


    }
}
