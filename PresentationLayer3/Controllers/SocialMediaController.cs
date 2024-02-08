using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SocialMediaController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = new List<Post>();
            
            using (var context = new Context())
            {
                 value = context.Posts.ToList();
            }
            //var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            //foreach(var item in value)
            //{

            //}
            return View(value);
        }
    }
}
