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
    public interface IOrdersRepository
    {
        [OperationContract]
        IEnumerable<Order> GetAllOrders();
        [OperationContract]
        Order GetOrder(int id);
        [OperationContract]
        void CreateOrder(Order item);
        [OperationContract]
        void UpdateOrder(Order item);
        [OperationContract]
        void DeleteOrder(int id);
    }
}
