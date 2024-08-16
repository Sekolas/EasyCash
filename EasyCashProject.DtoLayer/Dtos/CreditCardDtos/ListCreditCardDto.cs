using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DtoLayer.Dtos.CreditCardDtos
{
    public class ListCreditCardDto
    {
        public string CreditCardNumber { get; set; } // Musteri hesap numarasi (IBAN yerine kullanilmaktadir)
        public int? CVC { get; set; } // Kart dogrulama kodu (3 haneli)
        public string? ExpirationDate { get; set; } // Kartin son kullanim tarihi
        public decimal CreditCardBalance { get; set; } // Hesap bakiyesi
        public string? BankBranch { get; set; }  // Banka subesi
        public bool CreditCardStatus { get; set; } // Kredi karti basvurusu onaylandiysa true onaylanmadiysa false
        public int AppUserID { get; set; } // Bu hesap kime ait?
    }
}
