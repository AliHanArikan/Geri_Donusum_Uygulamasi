﻿using DtoLayer.Dtos.LoginAppUserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewDto loginViewDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewDto.Username, loginViewDto.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginViewDto.Username);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "NormalUser");
                }
                else
                {

                }

            }
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }

    
}
