using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using Prism.Mvvm;
using UserDbServices.DTO;

namespace MainAppModule.ViewModels
{
    public class NameViewModel : BindableBase
    {
        private UserDbDllServices _services;
        private UserDto _currentUser;
        public UserDto CurrentUser
        {
            get
            {
                _currentUser = _services.GetCurrentUser();
                return _currentUser;
            }
        }

        public DateTime CurrentDateTime { get; set; }
        public NameViewModel()
        {
            CurrentDateTime = DateTime.Now;
            _services = new UserDbDllServices();
        }
    }
}
