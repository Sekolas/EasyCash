using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    // Musterinin hesap bilgilerini icerecek tablo
    public class CustomerAccount
    {
        public int CustomerAccountID { get; set; }
        public string CustomerAccountNumber { get; set; } // Musteri hesap numarasi (IBAN yerine kullanilmaktadir)
        public int? CVC { get; set; } // Kart dogrulama kodu (3 haneli)
        public string? ExpirationDate { get; set; } = (DateTime.Now.Day + "/" + DateTime.Now.AddYears(3).Year).ToString(); // Kartin son kullanim tarihi
        public string CustomerAccountCurrency { get; set; } // Hesabin Döviz bilgisi
        public decimal CustomerAccountBalance { get; set; } = 0; // Hesap bakiyesi
        public string? BankBranch { get; set; }  // Banka subesi
        public int AppUserID { get; set; } // Bu hesap kime ait?
        public AppUser AppUser { get; set; }

        // Para transferi icin iliskiler
        public List<CustomerAccountProcess> CustomerSender { get; set; }
        public List<CustomerAccountProcess> CustomerReceiver { get; set; }
    }
}
