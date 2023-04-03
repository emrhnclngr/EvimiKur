using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Common;
using EvimiKur.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var address = await _addressService.GetList(userId);
            
            return View(address);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressCreateDto dto)
        {
            dto.AppUserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            
            var address = await _addressService.CreateAsync(dto);

            return this.ResponseRedirectAction(address, "Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _addressService.GetByIdAsync<AddressUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddressUpdateDto dto)
        {

            var address = await _addressService.UpdateAsync(dto);

            return this.ResponseRedirectAction(address, "Index");
        }

        public async Task<IActionResult> Remove (int id)
        {
            
            var removeAddress = await _addressService.RemoveAsync(id);

            return this.ResponseRedirectAction(removeAddress, "Index");
        }

    }
}
