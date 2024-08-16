using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Concrete;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyLastProcessController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public MyLastProcessController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = new Context();
            int id = context.CustomerAccounts.Where(x => x.AppUserID == user.Id && x.CustomerAccountCurrency == "TL").Select(y => y.CustomerAccountID).FirstOrDefault(); // Sisteme login olan kullanicinin id'sine gore CustomerAccount tablosundan CustomerAccountID alanini cekiyoruz.
            var values = _customerAccountProcessService.TMyLastProcess(id); // Son islemlerin listelenebilmesi icin ise sisteme login olan kullanicinin Musteri Hesap ID'sini gonderiyoruz
            return View(values);
        }
    }
}
