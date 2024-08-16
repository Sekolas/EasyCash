using AutoMapper;
using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DtoLayer.Dtos.CreditCardDtos;
using EasyCashProject.DtoLayer.Dtos.CustomerAccountDtos;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class CreditCardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;

        public CreditCardController(ICreditCardService creditCardService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var creditCardsByLoginUser = _creditCardService.TGetCreditCardsByTrue(user.Id);
            var mapCreditCards=_mapper.Map<List<ListCreditCardDto>>(creditCardsByLoginUser);
            return View(mapCreditCards);
        }

        [HttpGet]
        public async Task<IActionResult> CreditCartApplication()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = user.Name + " " + user.Surname;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreditCartApplication(CreditCard creditCard)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Random random = new Random();

            CreditCard creditCardApplication = new CreditCard()
            {
                CreditCardNumber = random.Next(10000000, 99999999).ToString(),
                CVC = random.Next(100, 999),
                BankBranch = creditCard.BankBranch,
                AppUserID = user.Id,
            };

            _creditCardService.TInsert(creditCardApplication);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
