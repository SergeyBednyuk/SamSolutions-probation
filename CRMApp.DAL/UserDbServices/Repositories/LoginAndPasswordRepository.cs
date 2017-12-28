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
    public class LoginAndPasswordRepository
    {
        private UsersDbContext _db = new UsersDbContext();

        public IEnumerable<LoginAndPassword> GetAll()
        {
            return _db.LoginAndPasswords.ToList();
        }

        public LoginAndPassword Get(int id)
        {
            return _db.LoginAndPasswords.FirstOrDefault(lp => lp.LoginAndPasswordId == id);
        }

        public void Create(LoginAndPassword item)
        {
            _db.LoginAndPasswords.Add(item);
        }

        public void Update(LoginAndPassword item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var logPass = _db.LoginAndPasswords.FirstOrDefault(lp => lp.LoginAndPasswordId == id);
            if (logPass != null)
            {
                _db.LoginAndPasswords.Remove(logPass);
            }
        }
    }
}
