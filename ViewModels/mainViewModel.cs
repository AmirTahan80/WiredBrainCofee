using System.Threading.Tasks;
using System.Windows.Input;
using WiredBrainCofee.CustumrsApp.Command;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        #region SelectedViewmodel, Full Property
        private BasicViewModel _selectedViewModel;

        public BasicViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Properties
        public CustomerViewModel CustomerViewModel { get; }
        public ProductViewModel ProductViewModel { get; }
        #endregion

        #region Constuctor
        public MainViewModel(CustomerViewModel customerViewModel,
            ProductViewModel productViewModel)
        {
            CustomerViewModel = customerViewModel;
            ProductViewModel = productViewModel;
            SelectedViewModel = CustomerViewModel;
        }
        #endregion

        #region Commands
        public ICommand SelectViewModelCommand => new CustomDelegateCommand(SelecViewModel!);
        #endregion

        #region Methods
        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
                await SelectedViewModel.LoadAsync();
        }

        private async void SelecViewModel(object? parameter)
        {
            SelectedViewModel = parameter as BasicViewModel;
            await LoadAsync();
        }
        #endregion

    }
}
