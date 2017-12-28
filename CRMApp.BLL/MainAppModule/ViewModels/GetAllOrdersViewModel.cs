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
    public class GetAllOrdersViewModel : BindableBase
    {
        private IUserDbDllServices _services;
        private ObservableCollection<OrderDto> _orders;
        public ObservableCollection<OrderDto> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                RaisePropertyChanged(nameof(Orders));
            }
        }

        private OrderDto _selectedOrder;
        public OrderDto SelectedOrder {
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


        public GetAllOrdersViewModel()
        {
            _addOrder = new OrderDto();//?
            _services = new UserDbDllServices();
            Orders = new ObservableCollection<OrderDto>(_services.GetAllOrders());
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
            Orders = new ObservableCollection<OrderDto>(_services.GetAllOrders());
        }

        #endregion
    }
}
