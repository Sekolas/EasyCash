using EasyCashProject.EntityLayer.Concrete;
using EasyCashProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];  // RegisterController tarafinda kayit olan kullanicinin mailini tasidik
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                // Email confirmed kısmı update edip True'ya dondurulecek
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
