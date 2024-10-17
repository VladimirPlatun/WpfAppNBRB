using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppNBRB.Model;
using WpfAppNBRB.Service;

namespace WpfAppNBRB.ViewModel
{
    public class RateViewModel : BaseViewModel
    {
        public RateViewModel() 
        {
            SelectedDate = DateTime.Now;
            Rates = new ObservableCollection<Rate>();
            GetRatesCommand = new RelayCommand<DateTime>(async (date) => await GetRatesAsync(date));

        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Rate> Rates { get; set; }

        public ICommand GetRatesCommand { get; }

        private async Task GetRatesAsync(DateTime selectedDate)
        {
            try
            {
                var rates = await _currencyService.GetRatesAsync(SelectedDate);
                Rates.Clear();
                
                foreach (var rate in rates)
                {
                    Rates.Add(rate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
