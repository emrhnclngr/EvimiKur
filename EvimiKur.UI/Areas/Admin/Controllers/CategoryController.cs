using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using System;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUow _uow;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IUow uow, ICategoryService categoryService, IMapper mapper)
        {
            _uow = uow;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {

            var response = await _categoryService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }

        public async Task<IActionResult> List()
        {

            //var response = await _categoryService.GetAllAsync();
            var response = await _categoryService.GetList(Common.Enums.StatusType.Active);
            return View(response);
            //return this.ResponseView(response);
        }
        public async Task<IActionResult> PassiveCategoryList()
        {
            var response = await _categoryService.GetList(Common.Enums.StatusType.Passive);
            return View(response);
        }
        public async Task<IActionResult> Update(int id)
        {

            var response = await _categoryService.GetByIdAsync<CategoryUpdateDto>(id);
            
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {

            var response = await _categoryService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }
        public async Task<IActionResult> Remove(int id)
        {

            var product = await _categoryService.GetByIdAsync<CategoryListDto>(id);
            if (product.Data.Status == true)
            {
                var response = await _categoryService.RemoveAsync(id);
                return this.ResponseRedirectAction(response, "List");
            }
            else
            {
                var response = await _categoryService.RemoveAsync(id);
                return this.ResponseRedirectAction(response, "PassiveCategoryList");
            }






            //var category = await _categoryService.GetByIdAsync<CategoryListDto>(id);
            //var response = await _categoryService.RemoveAsync(id);
            //return this.ResponseRedirectAction(response, "List");
        }

    }
}
