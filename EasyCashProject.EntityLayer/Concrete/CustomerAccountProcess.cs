using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    // Musterilerin birbirlerine yaptiklari havale eft islemlerini barindiracak olan tablo
    // (SenderID ve ReceiverID => CustomerAccount tablosundaki hesaplari icerecek. Yani yalnizca CustomerAccount tablosundaki ID'leri alabilir.)
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; } // islem turu
        public decimal Amount { get; set; } // Miktar - Ne kadar para gonderildi?
        public DateTime ProcessDate { get; set; }
        // Para transferi icin iliskiler
        public int? SenderID { get; set; } //Parayi gonderen kisi
        public int? ReceiverID { get; set; } // Parayi alan kisi
        public CustomerAccount SenderCustomer { get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }
        public string Description { get; set; }
    }
}
