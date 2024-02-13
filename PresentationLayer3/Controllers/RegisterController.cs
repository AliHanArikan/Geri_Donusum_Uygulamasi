using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer3.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            
            if (ModelState.IsValid)
            {
                Random random = new Random();
                AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    UserName = appUserRegisterDto.Username,
                    Email = appUserRegisterDto.EMail,
                    ConfirmCode = random.Next(100000, 1000000)
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password); ;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }

            }
            else
            {
               // return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return View();
        }
    }
}
