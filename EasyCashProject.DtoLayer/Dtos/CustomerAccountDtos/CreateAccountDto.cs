using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DtoLayer.Dtos.CustomerAccountDtos
{
    public class CreateAccountDto
    {
        public string CustomerAccountCurrency { get; set; } // Hesabin Döviz bilgisi
        public string? BankBranch { get; set; }  // Banka subesi
    }
}
