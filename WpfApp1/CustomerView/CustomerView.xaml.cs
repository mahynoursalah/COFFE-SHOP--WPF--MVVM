using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.DataProvider;
using WpfApp1.Model;

namespace WpfApp1.CustomerView
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }


        #region الطريقه القديمه لو ويندوز واحده    
        /*
        private CustomersViewModel _viewmodel;  // هعمل اوبجكت من فيو موديل عشان ابعته للفيو 
        public CustomerView()  
        {

            InitializeComponent();

            _viewmodel=new CustomersViewModel(new CustomerDataProvider());  // الكونستراكتور بتاع فيو موديل بيحتاح داتا بروافيدر فعمل اوبجكت من داتا بروفايدر 
            DataContext = _viewmodel;   // بقوله الداتا كنتكست بتاعتك خدها من فيو موديل يعني اي بايندينج في الزامل الكود بيهايند بتاعه هتلاقيه فالفيو موديل ++++++
            Loaded += CustomerView_Loaded;  //هات الداتا و ضيفها 

        }
        public async void CustomerView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewmodel.loadasync();
        }
        */
        #endregion

    }
}
