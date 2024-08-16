using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.Abstract
{
    public interface ICustomerAccountService : IGenericService<CustomerAccount>
    {
        List<CustomerAccount> TGetCustomerAccountsList(int id); // Sisteme login olan kullanicinin tum hesaplarini listeleyecek
        List<CustomerAccount> TGetCustomerAccountsListByMyCurrency(int userId, string myCurrency); // Gelen my currency (TL, USD, EUR) degerine ve sisteme giris yapan kullanicinin id'sine gore hesaplari listeleme
        List<CustomerAccount> TGetCustomerUSDAccountsList(int userId); // Sisteme login olan kullanicinin dolar hesaplarini listeleyecek
        List<CustomerAccount> TGetCustomerEURAccountsList(int userId); // Sisteme login olan kullanicinin euro hesaplarini listeleyecek
        CustomerAccount TGetCustomerAccount(string cardName, string cardNumber, string expiryDate, int cvc); // Gelen kart bilgilerine gore musteri hesabini dondurme

    }
}
