using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using EvimiKur.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using EvimiKur.Common.Enums;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<ProductCreateModel> _userCreateModelValidator;
        private readonly IProductStatusService _productStatusService;
        private readonly IMapper _mapper;
        private readonly IUow _uow;



        public ProductController(IProductService productService, ICategoryService categoryService, IValidator<ProductCreateModel> userCreateModelValidator, IMapper mapper = null, IUow uow = null, IProductStatusService productStatusService = null)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userCreateModelValidator = userCreateModelValidator;
            _mapper = mapper;
            _uow = uow;
            _productStatusService = productStatusService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {

            var response = await _categoryService.GetAllAsync();
            var resp = await _productStatusService.GetAllAsync();
            var model = new ProductCreateModel
            {
                Category = new SelectList(response.Data, "Id", "Name"),
                ProductStatus = new SelectList(resp.Data, "Id", "Definition")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {

            var dto = _mapper.Map<ProductCreateDto>(model);
            var response = await _productService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            //var products = await _productService.GetCategoryWithProduct();
            var products = await _productService.GetList(StatusType.Active);
            return View(products);

            //var response = await _productService.GetAllAsync();
            //return this.ResponseView(response);
        }
        public async Task<IActionResult> PassiveProductList()
        {
            var products = await _productService.GetList(StatusType.Passive);
            return View(products);

        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _productService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }




    }
}
