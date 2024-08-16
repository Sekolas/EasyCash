using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
