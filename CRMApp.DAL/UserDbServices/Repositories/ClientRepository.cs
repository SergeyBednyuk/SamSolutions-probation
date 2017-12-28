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

    public class ClientRepository
    {
        private UsersDbContext _db = new UsersDbContext();

        public IEnumerable<Client> GetAll()
        {
            return _db.Clients.ToList();
        }

        public Client Get(int id)
        {
            return _db.Clients.FirstOrDefault(c => c.ClientId == id);
        }

        public void Create(Client item)
        {
            _db.Clients.Add(item);
        }

        public void Update(Client item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            var client = _db.Clients.FirstOrDefault(c => c.ClientId == id);
            if (client != null)
            {
                _db.Clients.Remove(client);
            }
        }
    }
}
