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
    public class EfCreditCardDal : GenericRepository<CreditCard>, ICreditCardDal
    {
        public List<CreditCard> GetCreditCardsByTrue(int userId)
        {
            using var context = new Context();
            return context.CreditCards.Where(x=>x.AppUserID == userId && x.CreditCardStatus == true).ToList();
        }
    }
}
