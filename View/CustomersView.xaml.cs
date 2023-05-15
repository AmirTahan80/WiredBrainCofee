using System.Windows.Controls;

namespace WiredBrainCofee.CustumrsApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        //#region Properties
        //private CustomerViewModel _viewModel;
        //#endregion

        #region Constructors
        public CustomersView()
        {
            InitializeComponent();
            //_viewModel = new CustomerViewModel(new CustomerDataProvider());
            //DataContext = _viewModel;
            //Loaded += CustomersView_Loaded;
        }
        #endregion

        //#region Methods
        //private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    await _viewModel.LoadAsync();
        //}
        //#endregion
    }
}
