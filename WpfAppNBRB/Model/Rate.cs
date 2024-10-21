using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppNBRB.Model
{
    public class Rate : INotifyPropertyChanged
    {
        private int cur_ID;
        private DateTime date;
        private string cur_Abbreviation;
        private int cur_Scale;
        private string cur_Name;
        private decimal? cur_OfficialRate;

        public int Cur_ID
        {
            get => cur_ID;
            set
            {
                cur_ID = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        public string Cur_Abbreviation
        {
            get => cur_Abbreviation;
            set
            {
                cur_Abbreviation = value;
                OnPropertyChanged();
            }
        }

        public int Cur_Scale
        {
            get => cur_Scale;
            set
            {
                cur_Scale = value;
                OnPropertyChanged();
            }
        }

        public string Cur_Name
        {
            get => cur_Name;
            set
            {
                cur_Name = value;
                OnPropertyChanged();
            }
        }

        public decimal? Cur_OfficialRate
        {
            get => cur_OfficialRate;
            set
            {
                cur_OfficialRate = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
