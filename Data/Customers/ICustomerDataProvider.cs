using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.Data.Customers
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> GetAllAsync();
    }

    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            await Task.Delay(100);

            return new List<Customer>
            {
                new Customer{Id=1,FirstName="Amir",LastName="Tahan",IsDeveloper=true},
                new Customer{Id=2,FirstName="Hossein",LastName="Hosseini",IsDeveloper=true},
                new Customer{Id=3,FirstName="Ali",LastName="Moghadam",IsDeveloper=false},
                new Customer{Id=4,FirstName="Nader",LastName="Sloi",IsDeveloper=true},
                new Customer{Id=5,FirstName="Mahnaz",LastName="Sharif",IsDeveloper=false}
            };
        }
    }
}
