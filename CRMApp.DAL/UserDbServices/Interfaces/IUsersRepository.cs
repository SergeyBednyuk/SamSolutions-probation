using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserDbDll.Models;

namespace UserDbServices.Interfaces
{
    [ServiceContract]
    public interface IUsersRepository
    {
        [OperationContract]
        IEnumerable<User> GetAllUsers();
        [OperationContract]
        User GetUser(int id);
        [OperationContract]
        void CreateUser(User item);
        [OperationContract]
        void UpdateUser(User item);
        [OperationContract]
        void DeleteUser(int id);
    }
}
