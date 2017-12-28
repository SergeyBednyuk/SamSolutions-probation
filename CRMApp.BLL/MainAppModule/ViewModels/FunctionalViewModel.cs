using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAppModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using UserAuthorizationModule.Views;
using UserDbServices.DTO;

namespace MainAppModule.ViewModels
{
    public class FunctionalViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;

        public FunctionalViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _container = container;
            _eventAggregator = eventAggregator;
        }

        #region GetAllOrdersCurrentUser

        private DelegateCommand _getAllOrdersCurrentUserCommand;
        public DelegateCommand GetAllOrdersCurrentUserCommand
        {
            get
            {
                if (_getAllOrdersCurrentUserCommand == null)
                {
                    _getAllOrdersCurrentUserCommand = new DelegateCommand(GetAllOrdersCurrentUserExecute);
                }
                return _getAllOrdersCurrentUserCommand;
            }
        }

        private void GetAllOrdersCurrentUserExecute()
        {
            _regionManager.RequestNavigate("MainAppRegion", new Uri("GetAllOrdersCurrentUserView", UriKind.RelativeOrAbsolute));
        }

        #endregion

        #region GetAllOrders

        private DelegateCommand _getAllOrdersCommand;
        public DelegateCommand GetAllOrdersCommand
        {
            get
            {
                if (_getAllOrdersCommand == null)
                {
                    _getAllOrdersCommand = new DelegateCommand(GetAllOrdersExecute);
                }
                return _getAllOrdersCommand;
            }
        }

        private void GetAllOrdersExecute()
        {
            _regionManager.RequestNavigate("MainAppRegion", new Uri("GetAllOrdersView", UriKind.RelativeOrAbsolute));
        }

        #endregion

        #region GetAllClients

        private DelegateCommand _getAllClientsCommand;
        public DelegateCommand GetAllClientsCommand
        {
            get
            {
                if (_getAllClientsCommand == null)
                {
                    _getAllClientsCommand = new DelegateCommand(GetAllClientsExecute);
                }
                return _getAllClientsCommand;
            }
        }

        private void GetAllClientsExecute()
        {
            _regionManager.RequestNavigate("MainAppRegion", new Uri("GetAllClientsView", UriKind.RelativeOrAbsolute));
        }

        #endregion

        #region GetAllClientsCurrentUser

        private DelegateCommand _getAllClientsCurrentUserCommand;
        public DelegateCommand GetAllClientsCurrentUserCommand
        {
            get
            {
                if (_getAllClientsCurrentUserCommand == null)
                {
                    _getAllClientsCurrentUserCommand = new DelegateCommand(GetAllClientsCurrentUserExecute);
                }
                return _getAllClientsCurrentUserCommand;
            }
        }

        private void GetAllClientsCurrentUserExecute()
        {
            _regionManager.RequestNavigate("MainAppRegion", new Uri("GetAllClientsCurrentUserView", UriKind.RelativeOrAbsolute));
        }

        #endregion

    }
}
