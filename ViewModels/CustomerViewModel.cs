using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WiredBrainCofee.CustumrsApp.Command;
using WiredBrainCofee.CustumrsApp.Data.Customers;
using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public enum NavigationSide
    {
        Left,
        Right
    }
    public class CustomerViewModel : BasicViewModel
    {
        #region Properties
        private ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;
        public ObservableCollection<CustomerItemViewModel> Customers
        { get; } = new();
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                DeleteCustomerCommand.RaiseCanExecuteChanged();
            }
        }
        public NavigationSide NavigationColumn
        {
            get => _navigationSide; set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
        public CustomDelegateCommand DeleteCustomerCommand { get; }
        public ICommand AddCustomerCommand => new CustomDelegateCommand(AddCustomer!);
        public ICommand MoveNavigationSideCommand => new CustomDelegateCommand(MoveNavigationSide!);
        #endregion

        #region Constrctor
        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            DeleteCustomerCommand = new CustomDelegateCommand(DeleteCustomer!, CanDelete!);
        }
        #endregion 

        #region Methods
        internal async Task LoadAsync()
        {
            if (Customers.Any())
                return;

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }
        private void AddCustomer(object? parmeter)
        {
            var customer = new Customer { FirstName = "Ali" };
            var customerViewModel = new CustomerItemViewModel(customer);
            Customers.Add(customerViewModel);
            SelectedCustomer = customerViewModel;
        }
        private void MoveNavigationSide(object? parmeter)
        {
            NavigationColumn = NavigationColumn == NavigationSide.Right ? NavigationSide.Left : NavigationSide.Right;
        }
        private void DeleteCustomer(object? parameter)
        {
            MessageBox.Show($"{SelectedCustomer.FirstName} Deleted", "Success");
            Customers.Remove(SelectedCustomer!);
            SelectedCustomer = null;
        }
        private bool CanDelete(object? parameter) => SelectedCustomer is not null ? true : false;
        #endregion
    }
}
