using EasyCashProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashProject.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			if (ModelState.IsValid)
			{
				Random random = new Random();
				int code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDto.UserName,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.Surname,
					Email = appUserRegisterDto.Email,
					City = "Test",
					District = "Test",
					ImageUrl = "Test",
					ConfirmCode = code, // Email'e onay kodu gonderilecek ve email onaylama islemi gerceklestirilecek
				};
				var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
				if (result.Succeeded)
				{
					// Eger islem basarili olursa maile onay kodu gonderilecek
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "uiswagger@gmail.com"); // Mail kimden gidecek
					MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email); // Mail (onay kodu) kime gonderilecek

					mimeMessage.From.Add(mailboxAddressFrom); // Mail kimden gidecek
					mimeMessage.To.Add(mailboxAddressTo); // Mail kime gidecek

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code;
					mimeMessage.Body = bodyBuilder.ToMessageBody();

					mimeMessage.Subject = "Easy Cash Onay Kodu";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate("uiswagger@gmail.com", "jmntbheiwaqqtxyy");
					client.Send(mimeMessage);
					client.Disconnect(true);

					TempData["Mail"] = appUserRegisterDto.Email; // Kayit olan kisinin mailini ConfirmMail controller'ina ve oradaki Index sayfasina tasiyabilmek icin

					return RedirectToAction("Index", "ConfirmMail"); // Kullanici sisteme kaydolduktan sonra Mail onaylama sayfasina yonlendirilecek
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}
