using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using UserDbDll;
using UserDbDll.Models;
using UserDbDTo.DTO;
using UserDbServices.Interfaces;

namespace UserDbServices
{
    public class UnityOfWork : IUnityOfWork
    {
        private UsersDbContext _db = new UsersDbContext();

        public void Save()
        {
            _db.SaveChanges();
        }

        #region IUnitOfWork

        public ICollection<ClientDto> GetAllClientDtos()
        {
            return Mapper.Map<ICollection<Client>, ICollection<ClientDto>>(_db.Clients.ToList());
        }

        public ICollection<OrderDto> GetAllOrderDtos()
        {
            return Mapper.Map<ICollection<Order>, ICollection<OrderDto>>(_db.Orders.ToList());
        }

        public ICollection<UserDto> GetAllUserDtos()
        {
            return Mapper.Map<ICollection<User>, ICollection<UserDto>>(_db.Users.ToList());
        }

        public ICollection<OrderDto> GetAllOrdersCurrentUser(int currentUserId)
        {
            var query = from orders in _db.Orders
                        join user in _db.Users.Where(u => u.UserId == currentUserId) on orders.UserId equals user.UserId
                        select orders;

            return Mapper.Map<ICollection<Order>, ICollection<OrderDto>>(query.ToList());
        }

        public ICollection<OrderDto> GetAllOrdersCurrentClient(int currentClientId)
        {
            var query = from orders in _db.Orders.Where(o => o.ClientId == currentClientId)
                        select orders;

            return Mapper.Map<ICollection<Order>, ICollection<OrderDto>>(query.ToList());
        }

        public ICollection<OrderDto> GetAllOrderDtosTheCompany(string companyName)
        {
            var query = from orders in _db.Orders
                        join clients in _db.Clients.Where(c => c.Company == companyName) on orders.ClientId
                        equals clients.ClientId
                        select orders;

            return Mapper.Map<ICollection<Order>, ICollection<OrderDto>>(query.ToList());
        }

        public UserDto UserDtoAuthorization(string login, string password)
        {
            var query = from user in _db.Users
                        join logPass in _db.LoginAndPasswords
                            .Where(lp => lp.Login == login && lp.Password == password)
                        on user.LoginAndPasswordId equals logPass.LoginAndPasswordId
                        select user;

            return Mapper.Map<User, UserDto>(query.FirstOrDefault());
        }

        public ICollection<ClientDto> GetAllClientsCurrentUser(int currentUserId)
        {
            //var query = from orders in _db.Orders.Where(c => c.ClientId == currentUserId)
            //    join clients in _db.Clients on orders.ClientId equals clients.ClientId 
            //    select clients;

            var query = from client in _db.Clients
                join order in _db.Orders.Where(o => o.UserId == currentUserId) on client.ClientId equals order.ClientId
                select client;

            return Mapper.Map<ICollection<Client>, ICollection<ClientDto>>(query.ToList());
        }

        public void AppUsers(UserDto updateUser)
        {
            _db.Users.Add(Mapper.Map<UserDto, User>(updateUser));
            _db.SaveChanges();
        }

        public void AddLoginAndPasswords(LoginAndPasswordDto updateLoginAndPassword)
        {
            _db.LoginAndPasswords.Add(Mapper.Map<LoginAndPasswordDto, LoginAndPassword>(updateLoginAndPassword));
            _db.SaveChanges();
        }

        public void AddClients(ClientDto updateClient)
        {
            _db.Clients.Add(Mapper.Map<ClientDto, Client>(updateClient));
            _db.SaveChanges();
        }

        public void AddOrders(OrderDto updateOrder)
        {
            var user = Mapper.Map<OrderDto, Order>(updateOrder);

            _db.Orders.Add(user);
            _db.SaveChanges();
        }

        public void UpdateOrders(OrderDto updateOrder)
        {
            var user = Mapper.Map<OrderDto, Order>(updateOrder);

            _db.Entry(user).State = EntityState.Modified;
        }



        #endregion

        #region IDispose

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IOrdersRepositiry

        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Orders;
        }

        public Order GetOrder(int id)
        {
            return _db.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void CreateOrder(Order item)
        {
            _db.Orders.Add(item);
        }

        public void UpdateOrder(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteOrder(int id)
        {
            Order order = _db.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }

        #endregion

        #region IClientsRepository

        public IEnumerable<Client> GetAllClients()
        {
            return _db.Clients;
        }

        public Client GetClient(int id)
        {
            return _db.Clients.FirstOrDefault(c => c.ClientId == id);
        }

        public void CreateClient(Client item)
        {
            _db.Clients.Add(item);
        }

        public void UpdateClient(Client item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteClient(int id)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.ClientId == id);
            if (client != null)
            {
                _db.Clients.Remove(client);
            }
        }

        #endregion

        #region ILoginAndPasswordsRepository

        public IEnumerable<LoginAndPassword> GetAllLoginAndPassword()
        {
            return _db.LoginAndPasswords;
        }

        public LoginAndPassword GetLoginAndPassword(int id)
        {
            return _db.LoginAndPasswords.FirstOrDefault(lp => lp.LoginAndPasswordId == id);
        }

        public void CreateLoginAndPassword(LoginAndPassword item)
        {
            _db.LoginAndPasswords.Add(item);
        }

        public void UpdateLoginAndPassword(LoginAndPassword item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteLoginAndPassword(int id)
        {
            LoginAndPassword logPass = _db.LoginAndPasswords.FirstOrDefault(lp => lp.LoginAndPasswordId == id);
            if (logPass != null)
            {
                _db.LoginAndPasswords.Remove(logPass);
            }
        }

        #endregion

        #region IUsersRepository

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        public User GetUser(int id)
        {
            return _db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public void CreateUser(User item)
        {
            _db.Users.Add(item);
        }

        public void UpdateUser(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteUser(int id)
        {
            User user = _db.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }

        #endregion


    }
}
