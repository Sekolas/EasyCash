using EasyCashProject.DataAccessLayer.Abstract;
using EasyCashProject.DataAccessLayer.Concrete;
using EasyCashProject.DataAccessLayer.Repositories;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();

            // SenderCustomer ve ReceiverCustomer ile birlikte AppUser ilişkisini dahil ediyoruz
            var values = context.CustomerAccountProcesses
                .Include(y => y.SenderCustomer)
                    .ThenInclude(s => s.AppUser)
                .Include(w => w.ReceiverCustomer)
                    .ThenInclude(r => r.AppUser)
                .Where(x => x.ReceiverID == id || x.SenderID == id)
                .ToList();

            return values;
        }
    }
}
