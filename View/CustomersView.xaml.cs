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
        #region Properties
        private CustomerViewModel _viewModel;
        #endregion

        #region Constructors
        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }
        #endregion

        #region Methods
        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
        private void BtnMoveMenu_Click(object sender, RoutedEventArgs e)
        {
            var column = Grid.GetColumn(customerList);
            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(customerList, newColumn);
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCustomer();
        }
        #endregion
    }
}
