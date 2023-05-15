using System;
using System.Windows;
using WiredBrainCofee.CustumrsApp.Data.Customers;
using WiredBrainCofee.CustumrsApp.ViewModels;

namespace WiredBrainCofee.CustumrsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly mainViewModel _viewMode;

        public MainWindow()
        {
            InitializeComponent();
            _viewMode = new mainViewModel(new CustomerViewModel(new CustomerDataProvider()));
            DataContext = _viewMode;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewMode.LoadAsync();
        }
    }
}
