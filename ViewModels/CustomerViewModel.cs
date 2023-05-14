using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WiredBrainCofee.CustumrsApp.Data.Customers;
using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<Customer>
            Customers
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

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
