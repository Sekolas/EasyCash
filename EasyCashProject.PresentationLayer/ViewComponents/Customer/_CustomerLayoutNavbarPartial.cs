using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutNavbarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _CustomerLayoutNavbarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.loginUserName = loginUser.Name;
            return View();
        }
    }
}
