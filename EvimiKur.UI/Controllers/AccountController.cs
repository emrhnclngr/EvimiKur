using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Bussiness.Services;
using EvimiKur.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvimiKur.Common.Enums;
using Udemy.AdvertisementApp.UI.Extensions;
using FluentValidation;
using System;
using System.Linq;
using EvimiKur.UI.Models;
using AutoMapper;
using EvimiKur.Common;
using EvimiKur.Entities.Entities;
using EvimiKur.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace EvimiKur.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IValidator<AppUserCreateModel> _appUserCreateModelValidator;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public AccountController(IAppUserService appUserService, IMapper mapper, IValidator<AppUserCreateModel> appUserCreateModelValidator, IUow uow)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _appUserCreateModelValidator = appUserCreateModelValidator;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {

            var genders = new List<SelectListItem>
            {
              new SelectListItem { Value = Gender.Erkek.ToString(), Text = "Male" },
              new SelectListItem { Value = Gender.Kadın.ToString(), Text = "Female" },
            };

            ViewBag.Genders = genders;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserCreateModel model)
        {


            var result = _appUserCreateModelValidator.Validate(model);
            if (result.IsValid)
            {

                var userDTO = _mapper.Map<AppUserCreateDto>(model);

                var createResponse = await _appUserService.CreateWithRoleAsync(userDTO, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(model);


        }


        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);
                //İlgili kullanıcın rollerini çekmemiz.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,dto.Username)
                };

                if (roleResult.ResponseType == Common.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }

                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));



                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

               
                bool rol = roleResult.Data.Any(x => x.Definition.Contains("Admin"));
                bool claimsRol = claimsIdentity.Claims.Any(x => x.Value.Contains("1"));
                

                if (rol == true || claimsRol == true)
                {




                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                    
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);
            return View(dto);

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
           CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
