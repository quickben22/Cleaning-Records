using CleaningRecords.Global;
using CleaningRecords.Moduli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Windows;

namespace CleaningRecords.DAL.Models
{
    public class CleaningJob : INotifyPropertyChanged
    {

        public CleaningJob()
        {
            _Locations = new Dictionary<int, string>();
        }


        public int Id { get; set; }


        private int? _LocationId;
        public int? LocationId { get { return _LocationId; } set { _LocationId = (value); this.OnPropertyChanged("LocationId"); } }

        private string _Location;
        public string Location { get { return _Location; } set { _Location = (value); this.OnPropertyChanged("Location"); } }
        private DateTime _Date;
        public DateTime Date { get { return _Date; } set { _Date = (value); this.OnPropertyChanged("Date"); } }
        private DateTime _TimeStart;
        public DateTime TimeStart { get { return _TimeStart; } set { _TimeStart = (value); this.OnPropertyChanged("TimeStart"); } }
        private DateTime _TimeEnd;
        public DateTime TimeEnd { get { return _TimeEnd; } set { _TimeEnd = (value); this.OnPropertyChanged("TimeEnd"); } }


        private double _NoOfHours;
        public double NoOfHours { get { return _NoOfHours; } set { _NoOfHours = (value); this.OnPropertyChanged("NoOfHours"); } }

        private int _Week;
        public int Week { get { return _Week; } set { _Week = (value); this.OnPropertyChanged("Week"); } }


        private int _Day;
        public int Day { get { return _Day; } set { _Day = (value); this.OnPropertyChanged("Day"); } }



        private decimal _Amount;
        public decimal Amount { get { return _Amount; } set { _Amount = (value); this.OnPropertyChanged("Amount"); } }

        private int _ClientId;
        public int ClientId
        {
            get
            {
                setLocations(_ClientId);

                return _ClientId;
            }
            set
            {
                _ClientId = (value); this.OnPropertyChanged("ClientId");
            }
        }
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

        private int? _ServiceId;
        public int? ServiceId { get { return _ServiceId; } set { _ServiceId = (value); this.OnPropertyChanged("ServiceId"); } }
        public Service Service { get; set; }

        private int _JobStatus;
        public int JobStatus { get { return _JobStatus; } set { _JobStatus = (value); this.OnPropertyChanged("JobStatus"); } }


        [NotMapped]
        public bool changed = false;

        private Dictionary<int, string> _Locations;
        [NotMapped]
        public Dictionary<int, string> Locations { get { return _Locations; } set { _Locations = (value); this.OnPropertyChanged("Locations"); } }





        private void setLocations(int _id)
        {


            try
            {


                if (Client != null)
                    Locations = new Dictionary<int, string> { { 0, Client.Address }, { 1, Client.Address2 }, { 2, Client.Address3 }, { 3, Client.Address4 } };
                else if (_id != 0)
                {
                    using (var db = new PodaciContext())
                    {
                        if (db.Clients.Any())
                        {
                            var c = db.Clients.FirstOrDefault(x => x.Id == _id);
                            Locations = new Dictionary<int, string> { { 0, c.Address }, { 1, c.Address2 }, { 2, c.Address3 }, { 3, c.Address4 } };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("setLocations Error: " + ex.Message);
            }

        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (prop == "Date" && Date != null)
            {
                Week = Fun.getWeek(Date);
                Day = Fun.getDay(Date);

            }



            if (prop == "ClientId")
                setLocations(_ClientId);



            if (PropertyChanged != null)
            {
                if (prop == "Date" && Date != null)
                {
                    RepeatJob = null;
                    RepeatJobId = null;

                }
                else if (prop != "Locations")
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
                        NoOfHours = ConvertTime();
                    }
                }
                else if (prop == "TimeEnd" && TimeEnd != null)
                {
                    if (TimeStart != null)
                    {

                        NoOfHours = ConvertTime();
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

                if (prop == "TimeEnd" || prop == "TimeStart" || prop == "ServiceId")
                {
                    Amount = ConvertAmount();
                }

                try
                {
                    using (var db = new PodaciContext())
                    {
                        db.Update(this);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CleaningJob Update Error: " + ex.Message);
                }


                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private double ConvertTime()
        {
            try
            {
                var time = TimeEnd - TimeStart;
                return Math.Round((time.Hours + ((double)time.Minutes) / 60), 2);
            }
            catch
            {
                return 0;
            }
        }


        private decimal ConvertAmount()
        {
            try
            {

                if (TimeEnd != null && TimeStart != null && ServiceId != null && ServiceId != 0)
                {
                    double amount = 0;
                    var hours = ConvertTime();
                    using (var db = new PodaciContext())
                    {
                        var rate = db.Services.FirstOrDefault(x => x.Id == ServiceId)?.Rate;
                        if (rate != null)
                            amount = (double)rate * hours;
                    }
                    return (decimal)amount;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("ConvertAmount Error: " + ex.Message);
            }
            return Amount;
        }


    }
}
