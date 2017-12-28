using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDbDll.Models;

namespace UserDbDll
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext()
            : base("UsersDbContext") { }

        static UsersDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new UsersDbInitializer());
        }

        //
        public DbSet<LoginAndPassword> LoginAndPasswords { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
