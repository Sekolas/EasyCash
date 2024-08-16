using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SkiaSharp;
using Microsoft.AspNetCore.Identity;
using EasyCashProject.EntityLayer.Concrete;
using EasyCashProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class QRCodeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public QRCodeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Giris yapan kullanicinin Türk Lirasi hesabinin IBAN bilgisine gore QR kod olusturma
            using var context = new Context();
            var loginUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var customerAccountNumber = context.CustomerAccounts.Where
                (x => x.AppUserID == loginUser.Id &
                x.CustomerAccountCurrency == "TL").Select(y => y.CustomerAccountNumber).FirstOrDefault();
            ViewBag.CustomerAccountNumber = customerAccountNumber;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Qr kodu olusturma
                QRCodeGenerator createCode = new QRCodeGenerator();
                QRCodeData qrCodeData = createCode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                
                // Qr kodu cizdirme islemleri
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeImage = qrCode.GetGraphic(20);

                using (SKBitmap bitmap = SKBitmap.Decode(qrCodeImage))
                {
                    using (SKImage image = SKImage.FromBitmap(bitmap))
                    {
                        using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
                        {
                            data.SaveTo(ms);
                            ViewBag.qrCodePNG = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
                ms.Position = 0;
            }
            return View();
        }
    }
}
