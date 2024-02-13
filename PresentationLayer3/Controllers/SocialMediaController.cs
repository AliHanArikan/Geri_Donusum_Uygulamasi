using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(UserManager<AppUser> userManager, ISocialMediaService socialMediaService)
        {
            _userManager = userManager;
            _socialMediaService = socialMediaService;
        }

        public async Task<IActionResult> Index()
        {
            var value = _socialMediaService.TGetAll();
            
            
            return View(value);
        }
    }
}
