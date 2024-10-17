using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNBRB.Service
{
    public static class ApiRoutes
    {
        public const string BaseUrl = "";
        public const string GetCurrenciesUrl = "https://api.nbrb.by/exrates/currencies";
        public const string GetRatesOnDateUrl = "https://api.nbrb.by/exrates/rates";
        public const string GetDynamicRatesUrl = "https://api.nbrb.by/exrates/rates/dynamics/";
    }
}
