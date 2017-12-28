using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using Prism.Commands;
using Prism.Mvvm;
using UserDbServices.DTO;

namespace MainAppModule.ViewModels
{
    public class GetAllClientsCurrentUserViewModel : BindableBase
    {
        private UserDbDllServices _services;

        private ObservableCollection<ClientDto> _clientsCurrentUser;
        public ObservableCollection<ClientDto> ClientsCurrentUser
        {
            get { return _clientsCurrentUser; }
            set
            {
                _clientsCurrentUser = value;
                RaisePropertyChanged(nameof(ClientsCurrentUser));
            }
        }

        private ObservableCollection<OrderDto> _ordersSelectedClientCurrentUser;

        public ObservableCollection<OrderDto> OrdersSelectedClientCurrentUser
        {
            get { return _ordersSelectedClientCurrentUser; }
            set
            {
                _ordersSelectedClientCurrentUser = value;
                RaisePropertyChanged(nameof(OrdersSelectedClientCurrentUser));
            }
        }
        private ClientDto _selecteClient;
        public ClientDto SelectedClient
        {
            get { return _selecteClient; }
            set
            {
                _selecteClient = value;
                RaisePropertyChanged(nameof(SelectedClient));
            }
        }

        public GetAllClientsCurrentUserViewModel()
        {
            _services = new UserDbDllServices();
            ClientsCurrentUser = new ObservableCollection<ClientDto>(_services.GetAllClients());
            SelectedClient = new ClientDto();
        }

        #region ShowdAdditionalInfoAboutClient

        private DelegateCommand _showdAdditionalInfo;

        public DelegateCommand ShowdAdditionalInfo
        {
            get
            {
                if (_showdAdditionalInfo == null)
                {
                    _showdAdditionalInfo = new DelegateCommand(ShowdAdditionalInfoExecute, ShowdAdditionalInfoCanExecute);
                }
                return _showdAdditionalInfo;
            }
        }

        private bool ShowdAdditionalInfoCanExecute()
        {
            //if (SelectedClient.ClientId < 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        private void ShowdAdditionalInfoExecute()
        {
            OrdersSelectedClientCurrentUser = new ObservableCollection<OrderDto>(_services.GetAllOrdersCurrentClient(SelectedClient.ClientId));
        }

        #endregion
    }
}
