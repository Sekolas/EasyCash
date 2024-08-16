using EasyCashProject.EntityLayer.Concrete;
using EasyCashProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync
                (loginViewModel.UserName, loginViewModel.Password, false, true); // 3. deger kullanicinin bilgileri tarayicida saklanmasin, 4. deger: birden fazla sifre yanlis girildigi zaman belli bir sure giris yapma kilitlenecek
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user.EmailConfirmed == true) // Eger giris yapmak isteyen kullanicinin EmailConfirmed alani true ise basarili sekilde giris yapilmis olunacak
                {
                    return RedirectToAction("Index", "MyAccounts");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
