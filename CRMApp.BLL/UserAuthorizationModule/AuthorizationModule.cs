using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using UserAuthorizationModule.Views;

namespace UserAuthorizationModule
{
    public class AuthorizationModule : IModule
    {
        public IUnityContainer Container { get; private set; }
        public IRegionManager RegionManager { get; private set; }

        public AuthorizationModule(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        public void Initialize()
        {
            Container.RegisterTypeForNavigation<UserAuthorizationView>("UserAuthorizationView");
            RegionManager.RegisterViewWithRegion("ContentRegion", typeof(UserAuthorizationView));
        }
    }
}
