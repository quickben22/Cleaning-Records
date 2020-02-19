using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class ServicesVM : INotifyPropertyChanged
    {

        private ObservableCollection<Service> _Services;
        public ObservableCollection<Service> Services { get { return _Services; } set { _Services = (value); this.OnPropertyChanged("Services"); } }

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
