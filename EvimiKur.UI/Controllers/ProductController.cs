﻿using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Dtos;
using EvimiKur.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<ProductCreateModel> _userCreateModelValidator;
        private readonly IMapper _mapper;


        public ProductController(IProductService productService, ICategoryService categoryService, IValidator<ProductCreateModel> userCreateModelValidator, IMapper mapper = null)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userCreateModelValidator = userCreateModelValidator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {

            var response = await _categoryService.GetAllAsync();
            var model = new ProductCreateModel
            {
                Category = new SelectList(response.Data, "Id", "Name")
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
        public async Task<IActionResult> List()
        {
            var response = await _productService.GetAllAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _productService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }




    }
}
