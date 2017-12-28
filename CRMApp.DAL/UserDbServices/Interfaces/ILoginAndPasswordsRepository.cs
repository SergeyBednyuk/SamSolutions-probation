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
    public interface ILoginAndPasswordsRepository
    {
        [OperationContract]
        IEnumerable<LoginAndPassword> GetAllLoginAndPassword();
        [OperationContract]
        LoginAndPassword GetLoginAndPassword(int id);
        [OperationContract]
        void CreateLoginAndPassword(LoginAndPassword item);
        [OperationContract]
        void UpdateLoginAndPassword(LoginAndPassword item);
        [OperationContract]
        void DeleteLoginAndPassword(int id);
    }
}
