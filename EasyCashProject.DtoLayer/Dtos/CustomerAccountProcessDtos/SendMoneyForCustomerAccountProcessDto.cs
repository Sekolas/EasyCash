using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DtoLayer.Dtos.CustomerAccountProcessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {
        public string ProcessType { get; set; } // islem turu
        public string CustomerAccountCurrency { get; set; } // Para gonderecek kisinin hangi hesap turunden oldugunu belirtmek icin (Dolar hesabi mi, Euro hesabi mi?)
        public decimal Amount { get; set; } // Miktar - Ne kadar para gonderildi?
        public DateTime ProcessDate { get; set; }
        public int SenderID { get; set; } //Parayi gonderen kisi
        public int ReceiverID { get; set; } // Parayi alan kisi
        public string ReceiverAccountNumber { get; set; } // Alicinin hesap numarasi
        public string Description { get; set; }
    }
}
