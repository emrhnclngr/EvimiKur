using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Common.Enums;
using EvimiKur.DataAccess.Context;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Entities.Entities;
using EvimiKur.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        

        public async Task<IActionResult> List(string query)
        {
            return View(await _productService.Search(query));
        }
        public async Task<IActionResult> Page(int id)
        {
            var product = await _productService.GetByIdAsync<ProductListDto>(id);
            return this.ResponseView(product);
        }

        
        
        public async Task<IActionResult> Index(int categoryId)
        {

            if (categoryId == 0)
            {
                var products = await _productService.GetList(StatusType.Active);
                return View(products);
            }
            else
            {
                var products = await _productService.GetProductByCategories(categoryId,StatusType.Active);
               
                return View(products);
            }


        }

    }
}
