using System.Windows;
using WpfApp1.ViewModel;
using WpfApp1.Model;
using WpfApp1.DataProvider;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private MainViewModel _ViewModel;

        public MainWindow(MainViewModel _Main) //main window hb3tlo view model yt3aml m3ah fel app.xaml.cs
        {
            InitializeComponent();
            _ViewModel = _Main;
            DataContext = _ViewModel;
            Loaded += MainWindow_Loaded
                ;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _ViewModel.loadasync();
        }
    }
}