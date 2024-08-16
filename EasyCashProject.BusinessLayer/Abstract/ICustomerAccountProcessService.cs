using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.Abstract
{
    public interface ICustomerAccountProcessService : IGenericService<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> TMyLastProcess(int id); // Sisteme login olan kisinin id'si ile o kisinin son islemlerini listeleyecegiz 
    }
}
