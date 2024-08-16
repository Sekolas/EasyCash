using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int> // User tablosunun ID alani varsayilan Guid oldugu icin bunun yerine int olsun
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int ConfirmCode { get; set; } // Maile gonderilecek olan onay kodu
        public List<CustomerAccount> CustomerAccounts { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}
