using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCofee.CustumrsApp.Data.Customers;
using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class CustomerViewModel : BasicViewModel
    {
        #region Properties
        private ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public ObservableCollection<Customer> Customers
        { get; } = new();
        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constrctor
        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
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
                    Customers.Add(customer);
                }
            }
        }
        internal void AddCustomer()
        {
            var customer = new Customer { FirstName = "Ali" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }
        #endregion
    }
}
