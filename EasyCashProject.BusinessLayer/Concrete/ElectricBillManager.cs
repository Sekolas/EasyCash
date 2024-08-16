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
    public class ElectricBillManager : IElectricBillService
    {
        private readonly IElectricBillDal _electricBillDal;

        public ElectricBillManager(IElectricBillDal electricBillDal)
        {
            _electricBillDal = electricBillDal;
        }

        public bool TCompletePayment(string name, string contractNumber, string cardName, string cardNumber, string expiryDate, int cvc)
        {
           return _electricBillDal.CompletePayment(name, contractNumber, cardName, cardNumber, expiryDate, cvc);
        }

        public void TDelete(ElectricBill t)
        {
            throw new NotImplementedException();
        }

        public ElectricBill TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ElectricBill> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(ElectricBill t)
        {
            throw new NotImplementedException();
        }

        public ElectricBill? TSearchDebt(string contractNumber, string customerName)
        {
            return _electricBillDal.SearchDebt(contractNumber, customerName);
        }

        public void TUpdate(ElectricBill t)
        {
            throw new NotImplementedException();
        }
    }
}
