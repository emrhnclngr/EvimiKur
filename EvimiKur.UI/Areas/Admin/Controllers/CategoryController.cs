using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var response = await _categoryService.GetListActiveCategory();
            return View(response);
            //return this.ResponseView(response);
        }
        public async Task<IActionResult> PassiveCategoryList()
        {
            var response = await _categoryService.GetListInActiveCategory();
            return View(response);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _categoryService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }

    }
}
