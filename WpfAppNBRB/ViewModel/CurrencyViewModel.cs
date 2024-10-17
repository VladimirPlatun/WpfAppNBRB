using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfAppNBRB.Interface;
using WpfAppNBRB.Model;
using WpfAppNBRB.Service;

namespace WpfAppNBRB.ViewModel
{
    public class CurrencyViewModel : BaseViewModel
    {
        public CurrencyViewModel()
        {
            LoadCurrencies();
        }

        private List<Currency> _currencies;
        public List<Currency> Currencies
        {
            get => _currencies;
            set 
            {
                _currencies = value;
                OnPropertyChanged("Currencies");
            }

        }

        private async void LoadCurrencies()
        {
            Currencies = await _currencyService.GetCurrenciesAsync();

        }

    }
}
