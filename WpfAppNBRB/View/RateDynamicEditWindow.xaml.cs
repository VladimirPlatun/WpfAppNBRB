using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppNBRB.ViewModel;

namespace WpfAppNBRB.View
{
    public partial class RateDynamicEditWindow : Window
    {
        private RateViewModel _viewModel;
        public RateDynamicEditWindow()
        {
            InitializeComponent();
            _viewModel = this.DataContext as RateViewModel;

            if(_viewModel.Rates.Count == 0) 
            {
                DateTime NowDate = DateTime.Now;
                if (_viewModel.GetRatesCommand.CanExecute(NowDate))
                {
                    _viewModel.GetRatesCommand.Execute(NowDate);
                }
            }
        }
    }
}
