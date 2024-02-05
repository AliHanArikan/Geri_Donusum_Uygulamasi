using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.Controllers
{
    public class SocialMediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
