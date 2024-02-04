using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer3.Controllers
{
    public class UserCompetitionController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserCompetitionController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var userss = await _userManager.Users.ToListAsync();
            //var users = from user in userss
            //            orderby user.scrore descending
            //            select user; var sortedUsers = users.OrderBy(u => u.Name).ToList();
            var sortedUser = userss.OrderByDescending(x => x.scrore);
            return View(sortedUser);

           
        }
    }
}
