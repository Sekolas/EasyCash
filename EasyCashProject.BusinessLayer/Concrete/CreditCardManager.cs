using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public void TDelete(CreditCard t)
        {
            throw new NotImplementedException();
        }

        public CreditCard TGetByID(int id)
        {
            return _creditCardDal.GetByID(id);
        }

        public List<CreditCard> TGetCreditCardsByTrue(int userId)
        {
            return _creditCardDal.GetCreditCardsByTrue(userId);
        }

        public List<CreditCard> TGetList()
        {
            return _creditCardDal.GetList();
        }

        public void TInsert(CreditCard t)
        {
            _creditCardDal.Insert(t);
        }

        public void TUpdate(CreditCard t)
        {
            throw new NotImplementedException();
        }
    }
}
