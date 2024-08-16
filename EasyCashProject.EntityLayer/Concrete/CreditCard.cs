using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public string CreditCardNumber { get; set; } // Musteri hesap numarasi (IBAN yerine kullanilmaktadir)
        public int? CVC { get; set; } // Kart dogrulama kodu (3 haneli)
        public string? ExpirationDate { get; set; } = (DateTime.Now.Day + "/" + DateTime.Now.AddYears(3).Year).ToString(); // Kartin son kullanim tarihi
        public decimal CreditCardBalance { get; set; } = 10000; // Hesap bakiyesi
        public string? BankBranch { get; set; }  // Banka subesi
        public bool CreditCardStatus { get; set; } = false; // Kredi karti basvurusu onaylandiysa true onaylanmadiysa false
        public int AppUserID { get; set; } // Bu hesap kime ait?
        public AppUser AppUser { get; set; }

    }
}
