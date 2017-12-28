using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDbDll.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        //
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
