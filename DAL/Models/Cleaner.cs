using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class Cleaner : INotifyPropertyChanged
    {



        public int Id { get; set; }
        private string _Name;
        public string Name { get { return _Name; } set { _Name = (value); this.OnPropertyChanged("Name"); } }
        private string _Surname;
        public string Surname { get { return _Surname; } set { _Surname = (value); this.OnPropertyChanged("Surname"); } }
        private string _Address;
        public string Address { get { return _Address; } set { _Address = (value); this.OnPropertyChanged("Address"); } }
        private string _Telephone;
        public string Telephone { get { return _Telephone; } set { _Telephone = (value); this.OnPropertyChanged("Telephone"); } }

        private string _Email;
        public string Email { get { return _Email; } set { _Email = (value); this.OnPropertyChanged("Email"); } }

        private string _Contract;
        public string Contract { get { return _Contract; } set { _Contract = (value); this.OnPropertyChanged("Contract"); } }

        private string _PPS;
        public string PPS { get { return _PPS; } set { _PPS = (value); this.OnPropertyChanged("PPS"); } }

        private string _Visa;
        public string Visa { get { return _Visa; } set { _Visa = (value); this.OnPropertyChanged("Visa"); } }

        private string _DriversLicence;
        public string DriversLicence { get { return _DriversLicence; } set { _DriversLicence = (value); this.OnPropertyChanged("DriversLicence"); } }

        private string _Ironing;
        public string Ironing { get { return _Ironing; } set { _Ironing = (value); this.OnPropertyChanged("Ironing"); } }

        private string _Pets;
        public string Pets { get { return _Pets; } set { _Pets = (value); this.OnPropertyChanged("Pets"); } }

        private string _Color;
        public string Color { get { return _Color; } set { _Color = (value); this.OnPropertyChanged("Color"); } }


        public ObservableCollection<CleaningJob> CleaningJobs { get; set; }

        public List<CleanerTeam> CleanerTeams { get; set; }





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
