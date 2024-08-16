using EasyCashProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // Sisteme login olan kullanicinin bilgisini bulacak (UserName bilgisine gore)
            AppUserEditDto appUserEditDto = new AppUserEditDto();
            appUserEditDto.Name = values.Name;
            appUserEditDto.Surname = values.Surname;
            appUserEditDto.PhoneNumber = values.PhoneNumber;
            appUserEditDto.Email = values.Email;
            appUserEditDto.City = values.City;
            appUserEditDto.District = values.District;
            appUserEditDto.ImageUrl = values.ImageUrl;
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword) // Sifre ve Sifre tekrar alani eslesiyorsa
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = appUserEditDto.Name;
                user.Surname = appUserEditDto.Surname;
                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.City = appUserEditDto.City;
                user.District = appUserEditDto.District;
                user.ImageUrl = "";
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password); // Bu satir ile sifre alanini db'ye yine hash'lenmis formatta gonderebilecegiz.
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
