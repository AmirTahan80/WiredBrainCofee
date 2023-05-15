using System.Threading.Tasks;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class mainViewModel : BasicViewModel
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
        private CustomerViewModel _customerViewModel;
        #endregion

        public mainViewModel(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
            SelectedViewModel = _customerViewModel;
        }


        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
                await SelectedViewModel.LoadAsync();
        }

    }
}
