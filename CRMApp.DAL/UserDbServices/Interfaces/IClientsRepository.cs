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
    public interface IClientsRepository
    {
        [OperationContract]
        IEnumerable<Client> GetAllClients();
        [OperationContract]
        Client GetClient(int id);
        [OperationContract]
        void CreateClient(Client item);
        [OperationContract]
        void UpdateClient(Client item);
        [OperationContract]
        void DeleteClient(int id);
    }
}
