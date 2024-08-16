using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DtoLayer.Dtos.CustomerAccountDtos
{
    public class ListCustomerAccountDto
    {
        public string CustomerAccountNumber { get; set; } // Musteri hesap numarasi (IBAN yerine kullanilmaktadir)
        public int? CVC { get; set; } // Kart dogrulama kodu (3 haneli)
        public string? ExpirationDate { get; set; } // Kartin son kullanim tarihi
        public string CustomerAccountCurrency { get; set; } // Hesabin Döviz bilgisi
        public decimal CustomerAccountBalance { get; set; } // Hesap bakiyesi
        public string? BankBranch { get; set; }  // Banka subesi
        public int AppUserID { get; set; } // Bu hesap kime ait?
    }
}
