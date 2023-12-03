using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer3.ViewComponents
{
    public class _MainLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
