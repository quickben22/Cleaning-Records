using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CleanersViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<Cleaner> _Cleaners;
        public ObservableCollection<Cleaner> Cleaners { get { return _Cleaners; } set { _Cleaners = (value); this.OnPropertyChanged("Cleaners"); } }

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
