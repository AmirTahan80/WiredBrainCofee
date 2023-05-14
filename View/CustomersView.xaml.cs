using System.Windows;
using System.Windows.Controls;
using WiredBrainCofee.CustumrsApp.Data.Customers;
using WiredBrainCofee.CustumrsApp.ViewModels;

namespace WiredBrainCofee.CustumrsApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomerViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void BtnMoveMenu_Click(object sender, RoutedEventArgs e)
        {
            //var column = (int)customerList.GetValue(Grid.ColumnProperty);
            //var newColumn = column == 0 ? 2 : 0;
            //customerList.SetValue(Grid.ColumnProperty, newColumn);
            var column = Grid.GetColumn(customerList);
            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(customerList, newColumn);
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCustomer();
        }
    }
}
