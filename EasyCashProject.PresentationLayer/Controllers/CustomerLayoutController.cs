using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
