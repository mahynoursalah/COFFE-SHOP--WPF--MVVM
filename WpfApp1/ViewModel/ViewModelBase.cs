using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Model

{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public virtual Task loadasync()
        {
            return Task.CompletedTask;

        }

    }
   
    
}


