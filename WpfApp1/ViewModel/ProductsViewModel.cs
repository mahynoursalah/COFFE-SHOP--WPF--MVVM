using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DataProvider;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductsDataProvider _poductsViewModel;

        public ProductsViewModel(IProductsDataProvider productsDataProvider)
        {
            _poductsViewModel = productsDataProvider;
        }
        public ObservableCollection<Products> myproduct { get; } = new ObservableCollection<Products>();
        public override async Task loadasync()
        {
            if (myproduct.Any())
            {
                return;
            }
            var myproduct1 = await _poductsViewModel.GetAllAsync();
            if (myproduct1 is not null)
            {
                foreach (var product in myproduct1)
                {
                    myproduct.Add(product);
                }

            }
        }
    }
}
