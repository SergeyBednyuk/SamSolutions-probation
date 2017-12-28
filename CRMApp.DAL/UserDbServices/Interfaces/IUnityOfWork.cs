using System;
using System.Collections.Generic;
using System.ServiceModel;
using UserDbDTo.DTO;

namespace UserDbServices.Interfaces
{
    [ServiceContract]
    public interface IUnityOfWork : IDisposable, IRepository
    {      
        [OperationContract]
        void Save();
        [OperationContract]
        ICollection<ClientDto> GetAllClientDtos();
        [OperationContract]
        ICollection<OrderDto> GetAllOrderDtos();
        [OperationContract]
        ICollection<UserDto> GetAllUserDtos();
        [OperationContract]
        ICollection<OrderDto> GetAllOrdersCurrentUser(int currentUserId);
        [OperationContract]
        ICollection<OrderDto> GetAllOrdersCurrentClient(int currentClientId);
        [OperationContract]
        ICollection<OrderDto> GetAllOrderDtosTheCompany(string companyName);
        [OperationContract]
        UserDto UserDtoAuthorization(string login, string password);
        [OperationContract]
        ICollection<ClientDto> GetAllClientsCurrentUser(int currentUserId);

        [OperationContract]
        void AppUsers(UserDto updateUser);
        [OperationContract]
        void AddLoginAndPasswords(LoginAndPasswordDto updateLoginAndPassword);
        [OperationContract]
        void AddClients(ClientDto updateClient);
        [OperationContract]
        void AddOrders(OrderDto updateOrder);

    }
}
