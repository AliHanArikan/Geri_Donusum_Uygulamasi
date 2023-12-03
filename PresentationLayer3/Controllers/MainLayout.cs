using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.Controllers
{
    public class MainLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
