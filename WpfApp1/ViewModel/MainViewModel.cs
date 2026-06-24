using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Commands;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public ViewModelBase? SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        // switching logic
       
        public MainViewModel(CustomersViewModel customersViewModel , ProductsViewModel productsViewModel)
        {
            _CustomersViewModel = customersViewModel;
            _ProductsViewModel = productsViewModel;
            _selectedViewModel = customersViewModel;
            selectviewmodelcommand = new DelegateCommand(SelectViewModel);
        }

        // hna 3mlt two property 
        public  CustomersViewModel _CustomersViewModel { get; }
        public  ProductsViewModel _ProductsViewModel {  get; }

        //hna bb3t anhy view model 
        private async void SelectViewModel(object? Parameter)
        {
            SelectedViewModel = Parameter as ViewModelBase;
            await loadasync();
        }
        //delegate command 
        public DelegateCommand selectviewmodelcommand { get; }
        public override async Task loadasync()  
        {
            if (SelectedViewModel != null)
            {
                await SelectedViewModel.loadasync(); // Call the loadasync method of the selected view model (selected view model is type of ViewModelBase)
                //view model base must have load async method
            }
        }
    }
}
