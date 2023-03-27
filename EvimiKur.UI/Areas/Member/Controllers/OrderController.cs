using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EvimiKur.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class OrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IOrderService _orderService;


        public OrderController(IAppUserService appUserService, IOrderService orderService)
        {
            _appUserService = appUserService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail()
        {
            var UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);
            ViewBag.UserId = UserId;
            return View();
        }
        
        public async Task<IActionResult> Send()
        {
            var UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);
            ViewBag.UserId = UserId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Send(OrderCreateDto dto)
        {
            var UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);
            ViewBag.UserId = UserId;
            var order = await _orderService.CreateAsync(dto);
            return Redirect("~/Member/Home/Index");
        }

    }
}
