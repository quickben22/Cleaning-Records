using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
   public class ClientsViewModel : INotifyPropertyChanged
    {
      

        private ObservableCollection<Client> _Clients;
        public ObservableCollection<Client> Clients  { get { return _Clients; } set { _Clients = (value); this.OnPropertyChanged("Clients"); } }

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
