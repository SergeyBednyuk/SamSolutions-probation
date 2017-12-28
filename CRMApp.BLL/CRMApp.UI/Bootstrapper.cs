using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CRMApp.UI.Views;
using MainAppModule;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using UserAuthorizationModule;

namespace CRMApp.UI
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(AuthorizationModule));
            catalog.AddModule(typeof(MainModule));
        }

        
    }
}
