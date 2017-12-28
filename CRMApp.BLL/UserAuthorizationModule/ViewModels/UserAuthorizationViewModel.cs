using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BusinessLogicLayer.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using UserDbServices.DTO;

namespace UserAuthorizationModule.ViewModels
{
    public class UserAuthorizationViewModel : BindableBase
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private UserDbDllServices _services = new UserDbDllServices();

        private LoginAndPasswordDto _loginAndPassword;
        public LoginAndPasswordDto LoginAndPassword
        {
            get { return _loginAndPassword; }
            set
            {
                _loginAndPassword = value;
                OnPropertyChanged("LoginAndPassword");
            }
        }

        public UserAuthorizationViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            LoginAndPassword = new LoginAndPasswordDto();
        }

        private DelegateCommand _enterCommand;
        public DelegateCommand EnterCommand
        {
            get
            {
                if (_enterCommand == null)
                {
                    _enterCommand = new DelegateCommand(EnterExecute);
                }
                return _enterCommand;
            }
        }
        private void EnterExecute()
        {
            _services.UserDtoAuthorization(LoginAndPassword.Login, LoginAndPassword.Password);

            if (_services.GetCurrentUser() != null)
            {
                _regionManager.RequestNavigate("ContentRegion", new Uri("MainAppView", UriKind.RelativeOrAbsolute));

                LoginAndPassword.Login = String.Empty;
                LoginAndPassword.Password = String.Empty;
                //OnPropertyChanged("LoginAndPassword");

            }
            else
            {
                MessageBox.Show("Fault");
            }

        }


    }
}

