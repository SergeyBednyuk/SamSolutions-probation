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
    public class UserRepository
    {
        private UsersDbContext _db = new UsersDbContext();

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User Get(int id)
        {
            return _db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Update(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }
    }
}
