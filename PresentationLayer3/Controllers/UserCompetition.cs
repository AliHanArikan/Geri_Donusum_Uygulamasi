using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer3.Controllers
{
    public class UserCompetition : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserCompetition(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var userss = await _userManager.Users.ToListAsync();
            return View(userss);
           
        }
    }
}
