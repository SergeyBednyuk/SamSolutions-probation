using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAppModule.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace MainAppModule
{
    public class MainModule : IModule
    {
        public IUnityContainer Container { get; private set; }
        public IRegionManager RegionManager { get; private set; }

        public MainModule(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        public void Initialize()
        {
            Container.RegisterTypeForNavigation<NameView>("NameView");
            Container.RegisterTypeForNavigation<FunctionalView>("FunctionalView");
            Container.RegisterTypeForNavigation<ProgramNameView>("ProgramNameView");
            Container.RegisterTypeForNavigation<GetAllOrdersView>("GetAllOrdersView");
            Container.RegisterTypeForNavigation<GetAllOrdersCurrentUserView>("GetAllOrdersCurrentUserView");
            Container.RegisterTypeForNavigation<GetAllClientsView>("GetAllClientsView");
            Container.RegisterTypeForNavigation<GetAllClientsCurrentUserView>("GetAllClientsCurrentUserView");

            RegionManager.RegisterViewWithRegion("ContentRegion", typeof(MainAppView));
            RegionManager.RegisterViewWithRegion("FunctionalRegion", typeof(FunctionalView));
            RegionManager.RegisterViewWithRegion("NameRegion", typeof(NameView));
            RegionManager.RegisterViewWithRegion("ProgramNameRegion", typeof(ProgramNameView));
        }
    }
}
