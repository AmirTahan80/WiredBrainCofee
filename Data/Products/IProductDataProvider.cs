using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.Data.Products
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>?> GetAllAsync();
    }

    public class ProductDataProvider : IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100);

            return new List<Product>
            {
                new Product{Name="Golrang",Description ="Sabon Golrang" },
                new Product{Name="Kavir",Description ="Lastic Kavir" },
                new Product{Name="Dena",Description ="Mahin Dena" },
                new Product{Name="730Li",Description ="Mashin BMW" }
            };
        }
    }
}
