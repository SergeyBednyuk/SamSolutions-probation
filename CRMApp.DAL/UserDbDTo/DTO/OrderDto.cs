using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDbDTo.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        //
        public int ClientId { get; set; }
        public int UserId { get; set; }
    }
}
