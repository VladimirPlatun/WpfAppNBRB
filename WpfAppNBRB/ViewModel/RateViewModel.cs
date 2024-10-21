using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

            Rates.CollectionChanged += Rates_CollectionChanged;
        }

        private void Rates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
            {
                SaveRatesToFile();
            }
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

        private Rate selectedRate;
        public Rate SelectedRate
        {
            get { return selectedRate; }
            set
            {
                if (selectedRate != value)
                {
                    if (selectedRate != null)
                    {
                        selectedRate.PropertyChanged -= OnSelectedRateChanged;
                    }

                    selectedRate = value;
                    OnPropertyChanged();

                    if (selectedRate != null)
                    {
                        selectedRate.PropertyChanged += OnSelectedRateChanged;
                    }
                }
            }
        }

        private void OnSelectedRateChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Rate.Cur_Abbreviation) || e.PropertyName == nameof(Rate.Cur_OfficialRate))
            {
                SaveRatesToFile();
            }
        }
        private async void SaveRatesToFile()
        {
            await _fileSaver.SaveToJsonFileAsync($"rates_{Rates[0].Date.ToString("yyyy-MM-dd")}.json", Rates);
        }

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
                SaveRatesToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
