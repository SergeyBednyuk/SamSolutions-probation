using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDbDll.Models;

namespace UserDbDll
{
    public class UsersDbInitializer : DropCreateDatabaseIfModelChanges<UsersDbContext>
    {
        protected override void Seed(UsersDbContext usersDbContext)
        {
            usersDbContext.LoginAndPasswords.Add(new LoginAndPassword() { Login = "111", Password = "111" });
            usersDbContext.LoginAndPasswords.Add(new LoginAndPassword() { Login = "222", Password = "222" });
            usersDbContext.LoginAndPasswords.Add(new LoginAndPassword() { Login = "333", Password = "333" });
            usersDbContext.LoginAndPasswords.Add(new LoginAndPassword() { Login = "444", Password = "444" });

            usersDbContext.Clients.Add(new Client() { Company = "Nissan", DateTime = new DateTime(1933, 12, 26), Name = "Yoshisuke Aikawa" });
            usersDbContext.Clients.Add(new Client() { Company = "Toyota", DateTime = new DateTime(1937, 8, 28), Name = "Kiichiro Toyoda" });
            usersDbContext.Clients.Add(new Client() { Company = "Honda", DateTime = new DateTime(1948, 9, 24), Name = "Soichiro Honda" });
            usersDbContext.Clients.Add(new Client() { Company = "Porshe", DateTime = new DateTime(1931, 4, 25), Name = "Ferdinand Porsche" });
            usersDbContext.Clients.Add(new Client() { Company = "Tesla", DateTime = new DateTime(1971, 6, 28), Name = "Elon Musk" });
            usersDbContext.Clients.Add(new Client() { Company = "Mercedes-Benz", DateTime = new DateTime(1834, 3, 17), Name = "Gottlieb Daimler" });
            usersDbContext.Clients.Add(new Client() { Company = "Audi", DateTime = new DateTime(1868, 10, 12), Name = "August Horch" });

            usersDbContext.SaveChanges();

            usersDbContext.Users.Add(new User() { Name = "Ivan", SurName = "Ivanov", LoginAndPasswordId = 2 });
            usersDbContext.Users.Add(new User() { Name = "Petr", SurName = "Petrov", LoginAndPasswordId = 4 });

            usersDbContext.SaveChanges();
            //1
            usersDbContext.Orders.Add(new Order() { ClientId = 1, DateTime = new DateTime(2017, 9, 9), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 1, DateTime = new DateTime(2016, 10, 15), Name = "Break", UserId = 1, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 1, DateTime = new DateTime(2017, 10, 15), Name = "Steel", UserId = 1, Description = "develop 100 pounds of Steel" });
            usersDbContext.Orders.Add(new Order() { ClientId = 1, DateTime = new DateTime(2017, 12, 14), Name = "Engine", UserId = 2, Description = "develop 1000 Engines" });
            //2
            usersDbContext.Orders.Add(new Order() { ClientId = 2, DateTime = new DateTime(2017, 11, 11), Name = "Engine", UserId = 2, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 2, DateTime = new DateTime(2016, 12, 5), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 2, DateTime = new DateTime(2017, 1, 5), Name = "Steel", UserId = 1, Description = "develop 100 pounds of Steel" });
            usersDbContext.Orders.Add(new Order() { ClientId = 2, DateTime = new DateTime(2017, 2, 4), Name = "Engine", UserId = 2, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 2, DateTime = new DateTime(2017, 9, 2), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 2, DateTime = new DateTime(2016, 1, 23), Name = "Break", UserId = 1, Description = "develop 1000 Breaks" });
            //3
            usersDbContext.Orders.Add(new Order() { ClientId = 3, DateTime = new DateTime(2017, 11, 22), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 3, DateTime = new DateTime(2016, 10, 18), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 3, DateTime = new DateTime(2017, 1, 19), Name = "Steel", UserId = 1, Description = "develop 100 pounds of Steel" });
            usersDbContext.Orders.Add(new Order() { ClientId = 3, DateTime = new DateTime(2017, 2, 20), Name = "Engine", UserId = 2, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 3, DateTime = new DateTime(2017, 3, 1), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            //4
            usersDbContext.Orders.Add(new Order() { ClientId = 4, DateTime = new DateTime(2017, 11, 22), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 4, DateTime = new DateTime(2016, 10, 18), Name = "Break", UserId = 1, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 4, DateTime = new DateTime(2017, 1, 19), Name = "Steel", UserId = 1, Description = "develop 100 pounds of Steel" });
            //5
            usersDbContext.Orders.Add(new Order() { ClientId = 5, DateTime = new DateTime(2017, 9, 11), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 5, DateTime = new DateTime(2016, 2, 8), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 5, DateTime = new DateTime(2017, 11, 9), Name = "Steel", UserId = 1, Description = "develop 100 pounds of Steel" });
            usersDbContext.Orders.Add(new Order() { ClientId = 5, DateTime = new DateTime(2017, 4, 5), Name = "Engine", UserId = 1, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 5, DateTime = new DateTime(2016, 5, 20), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 5, DateTime = new DateTime(2017, 2, 11), Name = "Steel", UserId = 1, Description = "develop 100 pounds of Steel" });
            //6
            usersDbContext.Orders.Add(new Order() { ClientId = 6, DateTime = new DateTime(2016, 1, 8), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 6, DateTime = new DateTime(2017, 1, 9), Name = "Steel", UserId = 2, Description = "develop 100 pounds of Steel" });
            usersDbContext.Orders.Add(new Order() { ClientId = 6, DateTime = new DateTime(2017, 2, 5), Name = "Engine", UserId = 2, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 6, DateTime = new DateTime(2016, 3, 2), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 6, DateTime = new DateTime(2017, 6, 1), Name = "Steel", UserId = 2, Description = "develop 100 pounds of Steel" });
            //7
            usersDbContext.Orders.Add(new Order() { ClientId = 7, DateTime = new DateTime(2016, 9, 3), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 7, DateTime = new DateTime(2017, 10, 19), Name = "Steel", UserId = 2, Description = "develop 100 pounds of Steel" });
            usersDbContext.Orders.Add(new Order() { ClientId = 7, DateTime = new DateTime(2017, 7, 15), Name = "Engine", UserId = 2, Description = "develop 1000 Engines" });
            usersDbContext.Orders.Add(new Order() { ClientId = 7, DateTime = new DateTime(2016, 1, 10), Name = "Break", UserId = 2, Description = "develop 1000 Breaks" });
            usersDbContext.Orders.Add(new Order() { ClientId = 7, DateTime = new DateTime(2017, 5, 1), Name = "Steel", UserId = 2, Description = "develop 100 pounds of Steel" });

            usersDbContext.SaveChanges();
        }
    }
}
