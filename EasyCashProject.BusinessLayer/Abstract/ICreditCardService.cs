using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.Abstract
{
    public interface ICreditCardService : IGenericService<CreditCard>
    {
        List<CreditCard> TGetCreditCardsByTrue(int userId); // Login olan kullanicinin aktif/onaylanmis kredi kartlari
    }
}
