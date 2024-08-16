using AutoMapper;
using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DtoLayer.Dtos.CustomerAccountDtos;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class CustomerAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountService _customerAccountService;
        private readonly IMapper _mapper;

        public CustomerAccountController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService, IMapper mapper)
        {
            _userManager = userManager;
            _customerAccountService = customerAccountService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var loginUserAccountsList = _customerAccountService.TGetCustomerAccountsList(user.Id); // Giris yapan kisinin hesaplari listeleniyor
            return View(loginUserAccountsList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAccount()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = user.Name + " " + user.Surname;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccountDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Random random = new Random();

            CustomerAccount customerAccount = new CustomerAccount()
            {
                CustomerAccountNumber = random.Next(10000000, 99999999).ToString(),
                CVC = random.Next(100, 999),
                CustomerAccountCurrency = createAccountDto.CustomerAccountCurrency,
                BankBranch = createAccountDto.BankBranch,
                AppUserID = user.Id,
            };

            _customerAccountService.TInsert(customerAccount);
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> GetCustomerUSDAccountsList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var loginUserUSDAccountsList = _customerAccountService.TGetCustomerUSDAccountsList(user.Id); // Giris yapan kisinin dolar hesaplari listeleniyor
            var mapList = _mapper.Map<List<ListCustomerAccountDto>>(loginUserUSDAccountsList);
            return View(mapList);
        }

        public async Task<IActionResult> GetCustomerEURAccountsList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var loginUserEURAccountsList = _customerAccountService.TGetCustomerEURAccountsList(user.Id); // Giris yapan kisinin euro hesaplari listeleniyor
            var mapList = _mapper.Map<List<ListCustomerAccountDto>>(loginUserEURAccountsList);
            return View(mapList);
        }
    }
}
