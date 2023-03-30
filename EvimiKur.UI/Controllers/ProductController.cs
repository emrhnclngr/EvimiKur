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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EvimiKur.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;




        public ProductController(IUow uow, ICategoryService categoryService, EvimiKurContext context, IProductService productService, IMapper mapper)
        {
            _uow = uow;
            _categoryService = categoryService;
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetList(StatusType.Active);
           
            return View(products);
        }

        public async Task<IActionResult> List(string query)
        {

            return View(await _productService.Search(query));
        }


    }
}
