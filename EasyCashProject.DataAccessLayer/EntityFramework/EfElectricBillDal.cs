using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Concrete;
using EasyCashProject.DataAccessLayer.Repositories;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.EntityFramework
{
    public class EfElectricBillDal : GenericRepository<ElectricBill>, IElectricBillDal
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public EfElectricBillDal(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public bool CompletePayment(string name, string contractNumber, string cardName, string cardNumber, string expiryDate, int cvc)
        {
            using var context = new Context();
            ElectricBill electricPayment = SearchDebt(contractNumber, name); // Sozlesme numarasi ve ada gore elektrik faturasi geliyor
            var customerAccount = _customerAccountDal.GetCustomerAccount(cardName, cardNumber, expiryDate, cvc); // Kart bilgilerine gore musterinin hesabi getiriliyor.

            if(customerAccount.CustomerAccountBalance >= electricPayment.Amount) // Eger musterinin hesap bakiyesinde odemesi gereken miktar varsa islemleri gerceklestir
            {
                customerAccount.CustomerAccountBalance -= electricPayment.Amount; // Musterinin hesabindan elektrik faturasinin miktari kadar dusuluyor.
                context.CustomerAccounts.Update(customerAccount); // Musteri hesabini guncelleme islemi

                electricPayment.PaidStatus = true; // Elektrik faturasi odeme durumunu true'ya cekiyoruz.
                context.ElectricBills.Update(electricPayment); // Elektrik faturasi bilgisini guncelleme islemi

                context.SaveChanges(); // Bilgileri kaydetme islemi

                return true;
            }
            else
            {
                return false;
            }    
        }

        // Borc sorgulama islemi
        public ElectricBill? SearchDebt(string contractNumber, string customerName)
        {
            using var context = new Context();
            return context.ElectricBills.Where
                (x => x.ContractNumber == contractNumber && x.CustomerName == customerName).FirstOrDefault();
        }
    }
}
