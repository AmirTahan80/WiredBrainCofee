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
        private readonly MainViewModel _viewMode;

        public MainWindow()
        {
            InitializeComponent();
            _viewMode = new MainViewModel(new CustomerViewModel(new CustomerDataProvider()),
                new ProductViewModel());
            DataContext = _viewMode;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewMode.LoadAsync();
        }
    }
}
