using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Commands;
using WpfApp1.DataProvider;
using WpfApp1.Model;

namespace WpfApp1.ViewModel

{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand addcommand { get; }
        public DelegateCommand movenavigation { get; }
        public DelegateCommand deletecommand { get; }

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            addcommand = new DelegateCommand(add);
            movenavigation = new DelegateCommand(NavigationButton);
            deletecommand = new DelegateCommand(delete, CanDelete);
        }

        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null;
        }

        private void delete(object? parameter)
        {
            if (SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();
        // بص احنا هنا جبنا الداتا من الداتا بيز للفيو موديل بنتعامل معاها غلي طول و كده بقت مكشوفه لينا طب احنا لو عدلنا فالبروبيرتي بتاعتها هنا من بتاعت كلاس الكاستمر 
        // انا مش هحس بالتغيير فباقي الشاشه فاي داتا ليها علاقه بالكاستمر 
        // ليه ده بيحصل ؟ عشان ال customer in model مش بيورث من i notify property changed يعني مش بيبعت اشعار للشاشه لما يحصل تغيير في اي بروبيرتي من بروبيرتيز الكاستمر
        // الحل هعمل view model for customers class inherit from view model base

        // 1. بنعرف المتغير الخاص اللي هيشيل القيمة في الذاكرة
        private CustomerItemViewModel? _selectedCustomer;

        // 2. الـ Property اللي الشاشة بتعمل Binding عليها
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged(); // الجرس اللي بينبه الشاشة
                RaisePropertyChanged(nameof(IsCustomerSelected)); // بنادي الجرس بتاع البروبيرتي اللي بتقول هل في عميل متحدد ولا لأ عشان الشاشة تحدثها
                deletecommand.RaiseCanExecuteChanged(); // بنادي الديليت كوماند عشان يشيك لو ممكن ينفذ ولا لأ
            }
        }
        public bool IsCustomerSelected => SelectedCustomer is not null; // ديه بروبيرتي بتقول هل في عميل متحدد ولا لأ

        public UIElement CustomersList { get; private set; }
        //private int _navigationColumn;
        //public int NavigationColumn
        //{
        //    get => _navigationColumn;
        //    set
        //    {
        //        _navigationColumn = value;
        //        RaisePropertyChanged();
        //    }
        //}



        private NavigationSideEnum _navigationSide;
        public NavigationSideEnum NavigationSide
        {
            get => _navigationSide;
            set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

       

        public async override Task loadasync()
        {
            // 1. لو القائمة اللي جوه الـ ViewModel فيها داتا من المرة اللي فاتت.. اخرج فوراً!
            if (Customers.Any())
            {
                return;
            }

            // 2. لو مش فيها داتا (يعني دي أول مرة نفتح الشاشة)، روح نادى السيرفر
            var customers = await _customerDataProvider.GetAllAsync();

            // 3. اتأكد إن السيرفر رجع داتا فعلاً ومش فاضي
            if (customers is not null)
            {
                Customers.Clear(); // خطوة احتياطية لتنظيف السلة
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer)); // ضيف العملاء الجداد
                }
            }
        }

        internal void add(object? parameter)
        {
            var _customer = new Customer { FirstName = "New Customer" }; //new customer fro model class customer
            var customerViewModel = new CustomerItemViewModel(_customer);
            Customers.Add(customerViewModel);
            SelectedCustomer = customerViewModel;  // خلي الجديد هو اللي متحدد عن طريق استخدام inotifypropertychanged in viewmodel class
        }

        internal void NavigationButton(object? parameter)
        {
            //var column = (int)CustomersList.GetValue(Grid.ColumnProperty);
            //var newColumn = column == 0 ? 2 : 0;
            //CustomersList.SetValue(Grid.ColumnProperty, newColumn);
            //ANOTHER METHOD DONT NEED CASTING TO INT >>>>>>>>>>>
            //var column = Grid.GetColumn(CustomersList);
            //var newColumn = column == 0 ? 2 : 0;
            //Grid.SetColumn(CustomersList, newColumn);


            // NavigationColumn = NavigationColumn == 0 ? 2 : 0;  طيب هنا عملت ديه و عملت بره بايندينج عابروبيرتي بس مش عاجبني حتت الارقام هعمل ledt right 

            NavigationSide = NavigationSide == NavigationSideEnum.Left ? NavigationSideEnum.Right : NavigationSideEnum.Left; // لو كانت ال navigation side left خليها right و لو كانت right خليها left
        }

        public enum NavigationSideEnum
        {
            Left,
            Right
        }
    }
}


