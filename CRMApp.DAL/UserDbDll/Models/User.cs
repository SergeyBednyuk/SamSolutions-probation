using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDbDll.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        //
        public ICollection<Order> Orders { get; set; }

        public int LoginAndPasswordId { get; set; }
        public LoginAndPassword LoginAndPassword { get; set; }
    }
}
