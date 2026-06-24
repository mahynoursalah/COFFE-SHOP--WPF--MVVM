using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.DataProvider;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    public partial class App : Application
    {
        private readonly ServiceProvider _ServiceProvider;

        public App()
        
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            services.AddTransient<IProductsDataProvider,ProductsDataProvider>();




        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = _ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
