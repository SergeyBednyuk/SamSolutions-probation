using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDbDll.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        //
        public ICollection<Order> Orders { get; set; }
    }
}
