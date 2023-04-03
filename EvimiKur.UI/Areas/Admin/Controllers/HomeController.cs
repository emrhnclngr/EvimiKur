﻿using AutoMapper;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.DataAccess.UnitOfWork;
using EvimiKur.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.UI.Extensions;

namespace EvimiKur.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAppUserService _appUserService;


        public HomeController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var UserId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(UserId);

            return this.ResponseView(userResponse);
            
        }
    }
}
