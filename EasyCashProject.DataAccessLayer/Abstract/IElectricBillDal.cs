using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Abstract
{
    public interface IElectricBillDal : IGenericDal<ElectricBill>
    {
        ElectricBill? SearchDebt(string contractNumber, string customerName); // Sozlesme numarasi ve musteri adi soyadina gore fatura var mi yok mu bilgisi
        bool CompletePayment(string name, string contractNumber, string cardName, string cardNumber, string expiryDate, int cvc); // Odeme isleminin gerceklestirilmesi icin
    }
}
