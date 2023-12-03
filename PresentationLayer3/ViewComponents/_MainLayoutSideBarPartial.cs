using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.ViewComponents
{
    public class _MainLayoutSideBarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
