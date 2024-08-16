using EasyCashProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class ElectricBillController : Controller
    {
        private readonly IElectricBillService _electricBillService;

        public ElectricBillController(IElectricBillService electricBillService)
        {
            _electricBillService = electricBillService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QueryDebt(string contractNumber, string customerName) // 1. adim icin - Borc sorgulama kismi
        {
            ViewBag.ContractNumber = contractNumber;
            ViewBag.CustomerName = customerName;

            var result = _electricBillService.TSearchDebt(contractNumber, customerName);
            if (result.PaidStatus == true) // Eger borc odenmisse
            {
                return Json(new { message = "Ödenmemiş borcunuz bulunmamaktadır." });
            }
            else
            {
                return Json(new { success = true, debtAmount = result.Amount });
            }
        }

        [HttpPost]
        public IActionResult CompletePayment(string name, string contractNumber, string cardName, string cardNumber, string expiryDate, int cvc) // 3. Adim borc odeme islemi
        {
            // Odemeyi gerceklestirme islemi 

            var result = _electricBillService.TCompletePayment(name, contractNumber, cardName, cardNumber, expiryDate, cvc);
            return Json(new { success = result });
        }
    }
}
