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

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            DataContext = _viewMode;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewMode.LoadAsync();
        }
    }
}
