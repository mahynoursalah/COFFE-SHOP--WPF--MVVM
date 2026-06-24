using WpfApp1.Model;
using System;
using System.Collections.Generic;

namespace WpfApp1.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {

        private readonly Customer _customer;
        public CustomerItemViewModel(Customer customer)
        {
            _customer = customer;
        }

  
        public int id => _customer.Id;
        public string? FirstName
        {
            get
            {
                return _customer.FirstName;
            }
            set
            {
                _customer.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string? LastName
        {
            get
            {
                return _customer.LastName;
            }
            set
            {
                _customer.LastName = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get
            {
                return _customer.IsDeveloper;
            }
            set
            {
                _customer.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }
    }
}
