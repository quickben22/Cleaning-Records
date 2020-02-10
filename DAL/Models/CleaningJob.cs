using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CleaningJob : INotifyPropertyChanged
    {


        public int Id { get; set; }
        private string _Location;
        public string Location { get { return _Location; } set { _Location = (value); this.OnPropertyChanged("Location"); } }
        private DateTime _Date;
        public DateTime Date { get { return _Date; } set { _Date = (value); this.OnPropertyChanged("Date"); } }
        private DateTime _TimeStart;
        public DateTime TimeStart { get { return _TimeStart; } set { _TimeStart = (value); this.OnPropertyChanged("TimeStart"); } }
        private DateTime _TimeEnd;
        public DateTime TimeEnd { get { return _TimeEnd; } set { _TimeEnd = (value); this.OnPropertyChanged("TimeEnd"); } }


        private int _NoOfHours;
        public int NoOfHours { get { return _NoOfHours; } set { _NoOfHours = (value); this.OnPropertyChanged("NoOfHours"); } }
        private string _Team;
        public string Team { get { return _Team; } set { _Team = (value); this.OnPropertyChanged("Team"); } }
        private decimal _Amount;
        public decimal Amount { get { return _Amount; } set { _Amount = (value); this.OnPropertyChanged("Amount"); } }
        private string _AccountNumber;
        public string AccountNumber { get { return _AccountNumber; } set { _AccountNumber = (value); this.OnPropertyChanged("AccountNumber"); } }
        private int _ClientId;
        public int ClientId { get { return _ClientId; } set { _ClientId = (value); this.OnPropertyChanged("ClientId"); } }
        public Client Client { get; set; }


       


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
