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
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount t)
        {
            _customerAccountDal.Delete(t);
        }

        public CustomerAccount TGetByID(int id)
        {
            return _customerAccountDal.GetByID(id);
        }

        public CustomerAccount TGetCustomerAccount(string cardName, string cardNumber, string expiryDate, int cvc)
        {
            return _customerAccountDal.GetCustomerAccount(cardName, cardNumber, expiryDate, cvc);
        }

        public List<CustomerAccount> TGetCustomerAccountsList(int id)
        {
            return _customerAccountDal.GetCustomerAccountsList(id);
        }

        public List<CustomerAccount> TGetCustomerAccountsListByMyCurrency(int userId, string myCurrency)
        {
            return _customerAccountDal.GetCustomerAccountsListByMyCurrency(userId, myCurrency);
        }

        public List<CustomerAccount> TGetCustomerEURAccountsList(int userId)
        {
            return _customerAccountDal.GetCustomerEURAccountsList(userId);
        }

        public List<CustomerAccount> TGetCustomerUSDAccountsList(int userId)
        {
            return _customerAccountDal.GetCustomerUSDAccountsList(userId);
        }

        public List<CustomerAccount> TGetList()
        {
            return _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount t)
        {
            _customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
            _customerAccountDal.Update(t);
        }
    }
}
