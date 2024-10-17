using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfAppNBRB.Interface;
using WpfAppNBRB.Model;
using WpfAppNBRB.Service;

namespace WpfAppNBRB.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private protected readonly ICurrencyService _currencyService;

        public BaseViewModel()
        {
            _currencyService = new CurrencyService();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
