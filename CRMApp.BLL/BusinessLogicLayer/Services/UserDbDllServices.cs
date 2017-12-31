using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.UnitOfWork;
using Prism.Mvvm;
using UserDbDll.Models;
using UserDbDTo.DTO;

namespace BusinessLogicLayer.Services
{
    public class UserDbDllServices : BindableBase, IUserDbDllServices, IDisposable
    {
        private UnitOfWork.IUnityOfWork _unityOfWork = new UnityOfWorkClient();
        private static UserDto _currentUserDto;
        public static UserDto CurrentUserDto
        {
            get
            {
                return _currentUserDto;
            }
            set
            {
                _currentUserDto = value;
            }
        }

        //public UserDbDllServices()
        //{
        //    //CurrentUserDto = new UserDto();
        //}

        //public async Task<ICollection<ClientDto>> GetAllClients()
        //{
        //    return await _unityOfWork.GetAllClientDtosAsync();
        //}

        #region Async Await

        public async Task<ICollection<OrderDto>> GetAllOrderAsync()
        {
            var orders = await _unityOfWork.GetAllOrderDtosAsync();

            return orders;
        }

        #endregion

        public ICollection<ClientDto> GetAllClients()
        {
            return  _unityOfWork.GetAllClientDtos();
        }

        public ICollection<OrderDto> GetAllOrders()
        {
            return _unityOfWork.GetAllOrderDtos();
        }

        public ICollection<ClientDto> GetAllClientsCurrentUser(int currentUserId)
        {
            return _unityOfWork.GetAllClientsCurrentUser(currentUserId);
        }

        public ICollection<UserDto> GetAllUsers()
        {
            return _unityOfWork.GetAllUserDtos();
        }

        public ICollection<OrderDto> GetAllOrdersCurrentUser(int currentUserId)
        {
            return _unityOfWork.GetAllOrdersCurrentUser(currentUserId);
        }

        public ICollection<OrderDto> GetAllOrdersCurrentClient(int currentClientId)
        {
            return _unityOfWork.GetAllOrdersCurrentClient(currentClientId);
        }

        public ICollection<OrderDto> GetAllOrdersOneCompany(string companyName)
        {
            return _unityOfWork.GetAllOrderDtosTheCompany(companyName);
        }

        public void UserDtoAuthorization(string login, string password)
        {
            //TODO Acync
            CurrentUserDto = _unityOfWork.UserDtoAuthorization(login, password);
        }

        public void Save()
        {
            _unityOfWork.Save();
        }

        public UserDto GetCurrentUser()
        {
            return _currentUserDto;
        }

        public void AddClients(ClientDto updateClient)
        {
            _unityOfWork.AddClients(updateClient);
        }

        public void AddOrders(OrderDto updateOrder)
        {
            _unityOfWork.AddOrders(updateOrder);
        }

        public void Dispose()
        {

        }

    }
}
