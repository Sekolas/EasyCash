using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.EntityLayer.Concrete
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Message { get; set; }
        public string CreatedDate { get; set; } = DateTime.Now.ToShortDateString();
    }
}
