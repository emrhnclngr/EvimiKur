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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IDealerService _dealerService;
        private readonly IValidator<ProductCreateModel> _userCreateModelValidator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IUow _uow;



        public ProductController(IProductService productService, ICategoryService categoryService, IValidator<ProductCreateModel> userCreateModelValidator, IMapper mapper = null, IUow uow = null, IWebHostEnvironment webHostEnvironment = null, IDealerService dealerService = null)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userCreateModelValidator = userCreateModelValidator;
            _mapper = mapper;
            _uow = uow;
            _webHostEnvironment = webHostEnvironment;
            _dealerService = dealerService;
        }

       
        public async Task<IActionResult> Create()
        {

            var response = await _categoryService.GetAllAsync();
            var dealers = await _dealerService.GetAllAsync();
            var model = new ProductCreateModel
            {
                Category = new SelectList(response.Data, "Id", "Name"),
                Dealer = new SelectList(dealers.Data, "Id", "Name") 
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            string imageName = "noimage.png";
            if (model.UploadImage != null)
            {

                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");


                imageName = $"{Guid.NewGuid()}_{model.UploadImage.FileName}";


                string filePath = Path.Combine(uploadDir, imageName);


                FileStream fileStream = new FileStream(filePath, FileMode.Create);


                await model.UploadImage.CopyToAsync(fileStream);
                //stream'i kapatmazsak hata alırız
                fileStream.Close();
            }


            var dto = _mapper.Map<ProductCreateDto>(model);
            dto.Image = imageName;
            var response = await _productService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "Index");

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //var products = await _productService.GetCategoryWithProduct();
            var products = await _productService.GetListActiveProduct();
            return View(products);

            //var response = await _productService.GetAllAsync();
            //return this.ResponseView(response);
        }
        public async Task<IActionResult> List(string query)
        {

            return View(await _productService.Search(query));
        }
        public async Task<IActionResult> PassiveProductList()
        {
            var products = await _productService.GetListInActiveProduct();
            return View(products);

        }
        public async Task<IActionResult> Update(int id)
        {
          
            var response = await _productService.GetByIdAsync<ProductUpdateDto>(id);
            var categories = await _categoryService.GetListActiveCategory();
            var dealers = await _dealerService.GetListActiveDealers();
            ViewData["Categories"] = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewData["Dealers"] = dealers.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            

            string imageName = "noimage.png";
            if (dto.UploadImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");

                if (!string.Equals(dto.Image, "noimage.png"))
                {
                    string oldPath = Path.Combine(uploadDir, dto.Image);
                    if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                }
                imageName = $"{Guid.NewGuid()}_{dto.UploadImage.FileName}";
                string filePath = Path.Combine(uploadDir, imageName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await dto.UploadImage.CopyToAsync(fileStream);
                fileStream.Close();
            }
            dto.Image = imageName;
            var response = await _productService.UpdateAsync(dto);


            var categories = await _categoryService.GetListActiveCategory();
            var dealers = await _dealerService.GetListActiveDealers();
            ViewData["Categories"] = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewData["Dealers"] = dealers.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();


            return this.ResponseRedirectAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync<ProductListDto>(id);
            if (product.Data.Status == true)
            {
                var response = await _productService.RemoveAsync(id);
                return this.ResponseRedirectAction(response, "Index");
            }
            else
            {
                var response = await _productService.RemoveAsync(id);
                return this.ResponseRedirectAction(response, "PassiveProductList");
            }

        }




    }
}
