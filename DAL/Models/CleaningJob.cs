using CleaningRecords.Global;
using CleaningRecords.Moduli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows;

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

        private int _Week;
        public int Week { get { return _Week; } set { _Week = (value); this.OnPropertyChanged("Week"); } }


        private int _Day;
        public int Day { get { return _Day; } set { _Day = (value); this.OnPropertyChanged("Day"); } }



        private decimal _Amount;
        public decimal Amount { get { return _Amount; } set { _Amount = (value); this.OnPropertyChanged("Amount"); } }

        private int _ClientId;
        public int ClientId { get { return _ClientId; } set { _ClientId = (value); this.OnPropertyChanged("ClientId"); } }
        public Client Client { get; set; }


        private int? _CleanerId;
        public int? CleanerId { get { return _CleanerId; } set { _CleanerId = (value); this.OnPropertyChanged("CleanerId"); } }
        public Cleaner Cleaner { get; set; }


        private int? _TeamId;
        public int? TeamId { get { return _TeamId; } set { _TeamId = (value); this.OnPropertyChanged("TeamId"); } }
        public Team Team { get; set; }

        private int? _RepeatJobId;
        public int? RepeatJobId { get { return _RepeatJobId; } set { _RepeatJobId = (value); this.OnPropertyChanged("RepeatJobId"); } }
        public RepeatJob RepeatJob { get; set; }


        [NotMapped]
        public bool changed = false;




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (prop == "Date" && Date != null)
            {
                Week = Fun.getWeek(Date);
                Day = Fun.getDay(Date);

            }







            if (PropertyChanged != null)
            {
                if (prop == "Date" && Date != null)
                {
                    RepeatJob = null;
                    RepeatJobId = null;

                }
                else
                {
                    if (RepeatJobId != null && RepeatJob != null)
                    {
                        if (!changed)
                        {
                            changed = true;
                        
                        }

                    }
                }

                if (prop == "TimeStart" && TimeStart != null)
                {

                    if (TimeEnd != null)
                    {
                        NoOfHours = TimeEnd.Hour - TimeStart.Hour;
                    }
                }
                else if (prop == "TimeEnd" && TimeEnd != null)
                {
                    if (TimeStart != null)
                    {
                        NoOfHours = TimeEnd.Hour - TimeStart.Hour;
                    }
                }


                if (prop == "TeamId" && TeamId != null)
                    CleanerId = null;
                else if (prop == "CleanerId" && CleanerId != null)
                    TeamId = null;

                if (CleanerId == 0)
                    CleanerId = null;
                if (TeamId == 0)
                    TeamId = null;

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
