using DtoLayer.Dtos.LoginAppUserDtos;
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
            try
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
                else
                {
                    TempData["ErrorMessage"] = "An error occurred: ";
                }
            }catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
            }
            
            
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }

    
}
