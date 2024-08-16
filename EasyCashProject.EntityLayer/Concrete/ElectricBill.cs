using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    public class ElectricBill
    {
        public int ElectricBillID { get; set; }
        public string ContractNumber { get; set; }
        public string CustomerName { get; set; }
        public string BillingPeriod { get; set; } // Fatura donemi
        public DateTime PaymentDueDate { get; set; } // Son odeme tarihi
        public decimal Amount { get; set; }
        public bool PaidStatus { get; set; }
    }
}
