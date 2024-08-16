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
            var values = context.CustomerAccountProcesses
                .Include(y=>y.SenderCustomer)
                .Include(w => w.ReceiverCustomer)
                .ThenInclude(z=>z.AppUser) // User ve CustomerAccount tablolarini CustomerAccountProcess tablosuna dahil ettik (User bilgilerine ulasabilmek icin)
                .Where(x => x.ReceiverID == id || x.SenderID == id).ToList(); // Para gonderen veya alan kisi ID'si ile Sisteme login olan kisinin Musteri Hesap ID'si (gelen id degeri) esit ise listeleyecek
            return values;
        }
    }
}
