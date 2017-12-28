using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Prism.Commands;
using Prism.Mvvm;
using UserDbServices.DTO;

namespace MainAppModule.ViewModels
{
    public class GetAllClientsViewModel : BindableBase
    {
        private UserDbDllServices _services;

        private ObservableCollection<ClientDto> _clients;
        public ObservableCollection<ClientDto> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                RaisePropertyChanged(nameof(Clients));
            }
        }

        private ObservableCollection<OrderDto> _selectedOrder;

        public ObservableCollection<OrderDto> OrdersSelectedClient
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                RaisePropertyChanged(nameof(OrdersSelectedClient));
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

        public GetAllClientsViewModel()
        {
            _services = new UserDbDllServices();
            Clients = new ObservableCollection<ClientDto>(_services.GetAllClients());
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
            OrdersSelectedClient = new ObservableCollection<OrderDto>(_services.GetAllOrdersCurrentClient(SelectedClient.ClientId));
        }

        #endregion

    }
}
