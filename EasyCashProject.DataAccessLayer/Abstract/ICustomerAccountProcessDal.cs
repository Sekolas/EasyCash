using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.DataAccessLayer.Abstract
{
    public interface ICustomerAccountProcessDal : IGenericDal<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> MyLastProcess(int id); // Sisteme login olan kisinin id'si ile o kisinin son islemlerini listeleyecegiz 
    }
}
