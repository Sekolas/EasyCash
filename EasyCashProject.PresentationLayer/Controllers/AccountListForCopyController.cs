using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class AccountListForCopyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountService _customerAccountService;

        public AccountListForCopyController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService)
        {
            _userManager = userManager;
            _customerAccountService = customerAccountService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var customerAccountsByLogin = _customerAccountService.TGetCustomerAccountsList(user.Id);
            return View(customerAccountsByLogin);
        }
    }
}
