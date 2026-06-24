using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.DataProvider
{
    public interface IProductsDataProvider
    {
        Task<IEnumerable<Products>?> GetAllAsync();
    }

    public class ProductsDataProvider : IProductsDataProvider
    {
        public async Task<IEnumerable<Products>?> GetAllAsync()
        {
            await Task.Delay(100);
            return
            [
                new Products { Name = "Ice Coffee", Description = "Espresso with shot of milk" },
                new Products { Name = "Cappuccino", Description = "Espresso with steamed milk foam" },
                new Products { Name = "Latte", Description = "Smooth espresso with creamy milk" },
                new Products { Name = "Mocha", Description = "Chocolate flavored espresso drink" },
                new Products { Name = "Americano", Description = "Espresso diluted with hot water" },
                new Products { Name = "Flat White", Description = "Espresso with velvety steamed milk" },
                new Products { Name = "Caramel Macchiato", Description = "Espresso with vanilla and caramel" },
                new Products { Name = "Cold Brew", Description = "Slow brewed coffee served chilled" },
                new Products { Name = "Vanilla Frappuccino", Description = "Blended iced coffee with vanilla" },
                new Products { Name = "Hot Chocolate", Description = "Rich chocolate drink with milk" },
                new Products { Name = "Green Tea", Description = "Refreshing tea with natural flavor" }
            ];

        }
    }
}
