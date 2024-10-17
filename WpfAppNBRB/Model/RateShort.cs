using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNBRB.Model
{
    public class RateShort
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public decimal? Cur_OfficialRate { get; set; } 
    }
}
