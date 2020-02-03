using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class Client : INotifyPropertyChanged
    {
       


        public int Id { get; set; }
        private string _ClientNumber;
        public string ClientNumber { get { return _ClientNumber; } set { _ClientNumber = (value); this.OnPropertyChanged("ClientNumber"); } }
        private string _Name;
        public string Name { get { return _Name; } set { _Name = (value); this.OnPropertyChanged("Name"); } }
        private string _Surname;
        public string Surname { get { return _Surname; } set { _Surname = (value); this.OnPropertyChanged("Surname"); } }
        private string _Address;
        public string Address { get { return _Address; } set { _Address = (value); this.OnPropertyChanged("Address"); } }
        private string _Telephone;
        public string Telephone { get { return _Telephone; } set { _Telephone = (value); this.OnPropertyChanged("Telephone"); } }

        private string _Address2;
        public string Address2 { get { return _Address2; } set { _Address2 = (value); this.OnPropertyChanged("Address2"); } }

        private string _Address3;
        public string Address3 { get { return _Address3; } set { _Address3 = (value); this.OnPropertyChanged("Address3"); } }

        private string _Address4;
        public string Address4 { get { return _Address4; } set { _Address4 = (value); this.OnPropertyChanged("Address4"); } }

        private string _Description;
        public string Description { get { return _Description; } set { _Description = (value); this.OnPropertyChanged("Description"); } }

        private string _Instructions;
        public string Instructions { get { return _Instructions; } set { _Instructions = (value); this.OnPropertyChanged("Instructions"); } }


     

        private ObservableCollection<CleaningJob> _CleaningJobs;
        public ObservableCollection<CleaningJob> CleaningJobs { get { return _CleaningJobs; } set { _CleaningJobs = (value); this.OnPropertyChanged("CleaningJobs"); } }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {

                using (var db = new PodaciContext())
                {
                    db.Update(this);
                    db.SaveChanges();
                }

                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }



    }
}
