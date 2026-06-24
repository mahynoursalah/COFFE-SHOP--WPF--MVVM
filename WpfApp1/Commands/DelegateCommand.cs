using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Commands
{
 
  public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public DelegateCommand(Action<object?> execute , Func<object?,bool>? CanExecute=null)
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = CanExecute;
        }
       

        public bool CanExecute(object? parameter)
        {
            return _canExecute is null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
