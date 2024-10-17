using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppNBRB.Model;

namespace WpfAppNBRB.Interface
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetCurrenciesAsync();
        Task<List<Rate>> GetRatesAsync(DateTime selectedDate);
    }
}
