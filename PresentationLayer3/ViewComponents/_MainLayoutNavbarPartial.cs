using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.ViewComponents
{

    public class _MainLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
