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
using WpfAppNBRB.Model;
using WpfAppNBRB.ViewModel;

namespace WpfAppNBRB.View
{
    public partial class RateWindow : Window
    {
        private RateViewModel _viewModel;
        public RateWindow()
        {
            InitializeComponent();
            _viewModel = this.DataContext as RateViewModel;
        }
        private void OnGetRateClick(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = DatePicker.SelectedDate;

            if (selectedDate == null || selectedDate > DateTime.Now)
            {
                MessageBox.Show("Выберите корректную дату (не в будущем).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_viewModel.GetRatesCommand.CanExecute(selectedDate.Value))
            {
                _viewModel.GetRatesCommand.Execute(selectedDate.Value);
            }
        }
        
        private void OnOpenWidndowEditClick(object sender, RoutedEventArgs e)
        {
            RateDynamicEditWindow rateDynamicEditWindow = new RateDynamicEditWindow();

            rateDynamicEditWindow.Show();
        }

    }
}
