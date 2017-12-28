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
    public class GetAllOrdersCurrentUserViewModel : BindableBase
    {
        private IUserDbDllServices _services;
        private ObservableCollection<OrderDto> _ordersCurrentUser;

        public ObservableCollection<OrderDto> OrdersCurrentUser
        {
            get { return _ordersCurrentUser; }
            set
            {
                _ordersCurrentUser = value;
                RaisePropertyChanged(nameof(OrdersCurrentUser));
            }
        }

        private OrderDto _selectedOrder;
        public OrderDto SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                RaisePropertyChanged(nameof(SelectedOrder));
            }
        }

        private OrderDto _addOrder;
        public OrderDto AddOrder
        {
            get { return _addOrder; }
            set
            {
                _addOrder = value;
                RaisePropertyChanged(nameof(AddOrder));
            }
        }


        public GetAllOrdersCurrentUserViewModel()
        {
            _addOrder = new OrderDto();//?
            _services = new UserDbDllServices();
            OrdersCurrentUser = new ObservableCollection<OrderDto>(_services.GetAllOrdersCurrentUser(_services.GetCurrentUser().UserId));
        }

        #region AddOrder

        private DelegateCommand _addOrderCommand;

        public DelegateCommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new DelegateCommand(AddOrderExecute);
                }
                return _addOrderCommand;
            }
        }

        private void AddOrderExecute()
        {
            AddOrder.DateTime = DateTime.Now;
            _services.AddOrders(AddOrder);
            OrdersCurrentUser = new ObservableCollection<OrderDto>(_services.GetAllOrdersCurrentUser(_services.GetCurrentUser().UserId));
        }

        #endregion
    }
}
