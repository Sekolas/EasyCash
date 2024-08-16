using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
