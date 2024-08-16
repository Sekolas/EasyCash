using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Abstract
{
    public interface ICreditCardDal : IGenericDal<CreditCard>
    {
        List<CreditCard> GetCreditCardsByTrue(int userId); // Login olan kullanicinin aktif/onaylanmis kredi kartlari
    }
}
