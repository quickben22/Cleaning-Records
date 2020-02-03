using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CleaningJob : INotifyPropertyChanged
    {
      

        public int Id { get; set; }
        public string _Location;
        public string Location { get { return _Location; } set { _Location = (value); this.OnPropertyChanged("Location"); } }
        public DateTime _Date;
        public DateTime Date { get { return _Date; } set { _Date = (value); this.OnPropertyChanged("Date"); } }
        public DateTime _Time;
        public DateTime Time { get { return _Time; } set { _Time = (value); this.OnPropertyChanged("Time"); } }
        public int _NoOfHours;
        public int NoOfHours { get { return _NoOfHours; } set { _NoOfHours = (value); this.OnPropertyChanged("NoOfHours"); } }
        public string _Team;
        public string Team { get { return _Team; } set { _Team = (value); this.OnPropertyChanged("Team"); } }
        public decimal _Amount;
        public decimal Amount { get { return _Amount; } set { _Amount = (value); this.OnPropertyChanged("Amount"); } }
        public string _AccountNumber;
        public string AccountNumber { get { return _AccountNumber; } set { _AccountNumber = (value); this.OnPropertyChanged("AccountNumber"); } }

        public int ClientId { get; set; }
        public  Client Client { get; set; }


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
