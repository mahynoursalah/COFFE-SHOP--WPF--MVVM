using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp1.Model;
using static WpfApp1.ViewModel.CustomersViewModel;

namespace WpfApp1.Converters
{
    public class NavigationEnumToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var NavigationSide = (NavigationSideEnum)value;
            return NavigationSide == NavigationSideEnum.Left ? 0 : 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
