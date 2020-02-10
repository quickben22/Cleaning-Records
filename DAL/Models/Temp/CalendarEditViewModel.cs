using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CalendarEditViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<CleaningJob> _CleaningJobs;
        public ObservableCollection<CleaningJob> CleaningJobs { get { return _CleaningJobs; } set { _CleaningJobs = (value); this.OnPropertyChanged("CleaningJobs"); } }



  

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
