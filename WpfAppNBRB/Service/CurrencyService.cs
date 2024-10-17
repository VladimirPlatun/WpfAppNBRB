using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfAppNBRB.Interface;
using WpfAppNBRB.Model;

namespace WpfAppNBRB.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly FileSaver _fileSaver;
        private const string CurrenciesFilePath = "currencies.json";
        public CurrencyService()
        {
            _fileSaver = new FileSaver();
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            var cachedCurrencies = await _fileSaver.LoadFromJsonFileAsync<List<Currency>>(CurrenciesFilePath);

            if (cachedCurrencies != null && cachedCurrencies.Any())
            {          
                return cachedCurrencies;
            }

            string url = ApiRoutes.GetCurrenciesUrl;

            var res = await ApiCaller.Get(url);
            if (res == null) 
            {
                return new List<Currency>();
            }

            List<Currency> list = JsonConvert.DeserializeObject<List<Currency>>(res);

            await _fileSaver.SaveToJsonFileAsync("currencies.json", list);

            return list;
        }


        public async Task<List<Rate>> GetRatesAsync(DateTime selectedDate)
        {
            string dateParam = selectedDate.ToString("yyyy-MM-dd");

            var cachedRates = await _fileSaver.LoadFromJsonFileAsync<List<Rate>>($"rates_{dateParam}");

            if (cachedRates != null && cachedRates.Any())
            {
                return cachedRates;
            }

            string url = ApiRoutes.GetRatesOnDateUrl + $"?ondate={dateParam}&periodicity=0";

            var res = await ApiCaller.Get(url);
            if (res == null)
            {
                return new List<Rate>();
            }

            List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(res);

            await _fileSaver.SaveToJsonFileAsync($"rates_{dateParam}.json", rates);

            return rates;
        }
    }
}
