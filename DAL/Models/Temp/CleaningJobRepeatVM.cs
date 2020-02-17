using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CleaningJobRepeatVM : INotifyPropertyChanged
    {

        public CleaningJobRepeatVM()
        {
            _days = new ObservableCollection<bool> { false, false, false, false, false, false, false };
        }

        private int _RepeatId;
        public int RepeatId { get { return _RepeatId; } set { _RepeatId = (value); this.OnPropertyChanged("RepeatId"); } }

        private ObservableCollection<bool> _days;
        public ObservableCollection<bool> days
        {
            get { return _days; }
            set { _days = (value); this.OnPropertyChanged("days"); }
        }


        private bool _Monday;
        public bool Monday { get { return _Monday; } set { _Monday = (value); this.OnPropertyChanged("Monday"); } }

        private bool _Tuesday;
        public bool Tuesday { get { return _Tuesday; } set { _Tuesday = (value); this.OnPropertyChanged("Tuesday"); } }

        private bool _WednesDay;
        public bool WednesDay { get { return _WednesDay; } set { _WednesDay = (value); this.OnPropertyChanged("WednesDay"); } }

        private bool _Thursday;
        public bool Thursday { get { return _Thursday; } set { _Thursday = (value); this.OnPropertyChanged("Thursday"); } }

        private bool _Friday;
        public bool Friday { get { return _Friday; } set { _Friday = (value); this.OnPropertyChanged("Friday"); } }

        private bool _Saturday;
        public bool Saturday { get { return _Saturday; } set { _Saturday = (value); this.OnPropertyChanged("Saturday"); } }

        private bool _Sunday;
        public bool Sunday { get { return _Sunday; } set { _Sunday = (value); this.OnPropertyChanged("Sunday"); } }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {


                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }

    }
}
