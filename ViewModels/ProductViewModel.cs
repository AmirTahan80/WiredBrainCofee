using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCofee.CustumrsApp.Data.Products;
using WiredBrainCofee.CustumrsApp.Model;

namespace WiredBrainCofee.CustumrsApp.ViewModels
{
    public class ProductViewModel : BasicViewModel
    {
        private IProductDataProvider _productDataProvider;

        public ProductViewModel(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
                return;

            var products = await _productDataProvider.GetAllAsync();
            foreach (var item in products)
            {
                Products.Add(item);
            }
        }
    }
}
