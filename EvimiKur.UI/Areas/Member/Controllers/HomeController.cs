using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
       private readonly IAppUserService _appUserService;
       private readonly IUow _uow;
       private readonly IMapper _mapper;
       

        public HomeController(IAppUserService appUserService, IUow uow, IMapper mapper)
        {
            _appUserService = appUserService;
            _uow = uow;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Index()
        {
            var UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);

            return this.ResponseView(userResponse);

        }
        
        public async Task<IActionResult> Update(int id)
        {

            var response = await _appUserService.GetByIdAsync<AppUserUpdateDto>(id);
            return this.ResponseView(response);

        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateDto dto)
        {
            var response = await _appUserService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "Index");
        }


    }
}
