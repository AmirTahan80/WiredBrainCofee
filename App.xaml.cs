using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WiredBrainCofee.CustumrsApp.Data.Customers;

namespace WiredBrainCofee.CustumrsApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow(new ViewModels.MainViewModel(
                new ViewModels.CustomerViewModel(new CustomerDataProvider()),
                new ViewModels.ProductViewModel()));
            mainWindow.Show();
        }
    }
}
