using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDbDll;
using UserDbDll.Models;
using UserDbServices.Interfaces;

namespace UserDbServices.Repositories
{
    public class OrderRepository
    {
        private UsersDbContext _db = new UsersDbContext();

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return _db.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void Create(Order item)
        {
            _db.Orders.Add(item);
        }

        public void Update(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var order = _db.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }
    }
}
