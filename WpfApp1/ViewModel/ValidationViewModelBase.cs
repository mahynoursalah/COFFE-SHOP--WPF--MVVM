using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errorPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName is not null && _errorPropertyName.ContainsKey(propertyName) ? _errorPropertyName[propertyName] : Enumerable.Empty<string>();
            
            
        }
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e) { 
        
           ErrorsChanged?.Invoke(this, e); 
        }
    }
}
