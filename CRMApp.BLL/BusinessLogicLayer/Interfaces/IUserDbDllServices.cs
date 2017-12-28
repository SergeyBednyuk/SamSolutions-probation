using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDbServices.DTO;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserDbDllServices
    {
        //Task<ICollection<ClientDto>> GetAllClients();
        ICollection<ClientDto> GetAllClients();

        ICollection<OrderDto> GetAllOrders();

        ICollection<ClientDto> GetAllClientsCurrentUser(int currentUserId);

        ICollection<UserDto> GetAllUsers();

        ICollection<OrderDto> GetAllOrdersCurrentUser(int currentUserId);

        ICollection<OrderDto> GetAllOrdersCurrentClient(int currentClientId);

        ICollection<OrderDto> GetAllOrdersOneCompany(string companyName);

        void UserDtoAuthorization(string login, string password);

        void Save();

        UserDto GetCurrentUser();

        void AddClients(ClientDto updateClient);

        void AddOrders(OrderDto updateOrder);
    }
}
