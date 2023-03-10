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

namespace EvimiKur.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IValidator<AppUserCreateDto> _appUserCreateValidator;

        public AccountController(IAppUserService appUserService, IValidator<AppUserCreateDto> appUserCreateValidator)
        {
            _appUserService = appUserService;
            _appUserCreateValidator = appUserCreateValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {

            List<SelectListItem> genderList = new List<SelectListItem>
            {
              new SelectListItem { Value = Gender.Erkek.ToString(), Text = "Male" },
              new SelectListItem { Value = Gender.Kadın.ToString(), Text = "Female" },

            };


            SelectList selectList = new SelectList(genderList, "Value", "Text");


            return View(selectList);

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserCreateDto model)
        {
            var result = _appUserCreateValidator.Validate(model);
            if (result.IsValid)
            {

                var createResponse = await _appUserService.CreateWithRoleAsync(model, (int)RoleType.Member);
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
                var claims = new List<Claim>();

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

                return RedirectToAction("Index", "Home");
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
