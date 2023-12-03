using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.ViewComponents
{
    public class _MainLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
