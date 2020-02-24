using CleaningRecords.Moduli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CleaningRecords.DAL.Models.OldModels
{
    public class Cleaner : INotifyPropertyChanged
    {


        private int _Id { get; set; }
        public int Id { get { return _Id; } set { _Id = (value); this.OnPropertyChanged("Id"); } }

        private bool _IsActive;
        public bool IsActive { get { return _IsActive; } set { _IsActive = (value); this.OnPropertyChanged("IsActive"); } }

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


        private double _HoursWeekly;
        [NotMapped]
        public double HoursWeekly { get { return _HoursWeekly; } set { _HoursWeekly = (value); this.OnPropertyChanged("HoursWeekly"); } }

        public ObservableCollection<CleaningJob> CleaningJobs { get; set; }

        public List<CleanerTeam> CleanerTeams { get; set; }


        private int _CleanerStatus;
        public int CleanerStatus { get { return _CleanerStatus; } set { _CleanerStatus = (value); this.OnPropertyChanged("CleanerStatus"); } }



        private DateTime _MondayStart;
        public DateTime MondayStart { get { return _MondayStart; } set { _MondayStart = (value); this.OnPropertyChanged("MondayStart"); } }
        private DateTime _MondayEnd;
        public DateTime MondayEnd { get { return _MondayEnd; } set { _MondayEnd = (value); this.OnPropertyChanged("MondayEnd"); } }
        private DateTime _TuesdayStart;
        public DateTime TuesdayStart { get { return _TuesdayStart; } set { _TuesdayStart = (value); this.OnPropertyChanged("TuesdayStart"); } }

        private DateTime _TuesdayEnd;
        public DateTime TuesdayEnd { get { return _TuesdayEnd; } set { _TuesdayEnd = (value); this.OnPropertyChanged("TuesdayEnd"); } }
        private DateTime _WednesdayStart;
        public DateTime WednesdayStart { get { return _WednesdayStart; } set { _WednesdayStart = (value); this.OnPropertyChanged("WednesdayStart"); } }
        private DateTime _WednesdayEnd;
        public DateTime WednesdayEnd { get { return _WednesdayEnd; } set { _WednesdayEnd = (value); this.OnPropertyChanged("WednesdayEnd"); } }
        private DateTime _ThursdayStart;
        public DateTime ThursdayStart { get { return _ThursdayStart; } set { _ThursdayStart = (value); this.OnPropertyChanged("ThursdayStart"); } }
        private DateTime _ThursdayEnd;
        public DateTime ThursdayEnd { get { return _ThursdayEnd; } set { _ThursdayEnd = (value); this.OnPropertyChanged("ThursdayEnd"); } }
        private DateTime _FridayStart;
        public DateTime FridayStart { get { return _FridayStart; } set { _FridayStart = (value); this.OnPropertyChanged("FridayStart"); } }
        private DateTime _FridayEnd;
        public DateTime FridayEnd { get { return _FridayEnd; } set { _FridayEnd = (value); this.OnPropertyChanged("FridayEnd"); } }
        private DateTime _SaturdayStart;
        public DateTime SaturdayStart { get { return _SaturdayStart; } set { _SaturdayStart = (value); this.OnPropertyChanged("SaturdayStart"); } }
        private DateTime _SaturdayEnd;
        public DateTime SaturdayEnd { get { return _SaturdayEnd; } set { _SaturdayEnd = (value); this.OnPropertyChanged("SaturdayEnd"); } }
        private DateTime _SundayStart;
        public DateTime SundayStart { get { return _SundayStart; } set { _SundayStart = (value); this.OnPropertyChanged("SundayStart"); } }
        private DateTime _SundayEnd;
        public DateTime SundayEnd { get { return _SundayEnd; } set { _SundayEnd = (value); this.OnPropertyChanged("SundayEnd"); } }
        private DateTime _NotAvailableStart;
        public DateTime NotAvailableStart { get { return _NotAvailableStart; } set { _NotAvailableStart = (value); this.OnPropertyChanged("NotAvailableStart"); } }
        private DateTime _NotAvailableEnd;
        public DateTime NotAvailableEnd { get { return _NotAvailableEnd; } set { _NotAvailableEnd = (value); this.OnPropertyChanged("NotAvailableEnd"); } }


        private bool _Monday;
        public bool Monday { get { return _Monday; } set { _Monday = (value); this.OnPropertyChanged("Monday"); } }
        private bool _Tuesday;
        public bool Tuesday { get { return _Tuesday; } set { _Tuesday = (value); this.OnPropertyChanged("Tuesday"); } }
        private bool _Wednesday;
        public bool Wednesday { get { return _Wednesday; } set { _Wednesday = (value); this.OnPropertyChanged("Wednesday"); } }
        private bool _Thursday;
        public bool Thursday { get { return _Thursday; } set { _Thursday = (value); this.OnPropertyChanged("Thursday"); } }
        private bool _Friday;
        public bool Friday { get { return _Friday; } set { _Friday = (value); this.OnPropertyChanged("Friday"); } }
        private bool _Saturday;
        public bool Saturday { get { return _Saturday; } set { _Saturday = (value); this.OnPropertyChanged("Saturday"); } }
        private bool _Sunday;
        public bool Sunday { get { return _Sunday; } set { _Sunday = (value); this.OnPropertyChanged("Sunday"); } }
        private bool _NotAvailable;
        public bool NotAvailable { get { return _NotAvailable; } set { _NotAvailable = (value); this.OnPropertyChanged("NotAvailable"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (prop == "Id")
            {
                HoursWeekly = Fun.GetCleanerHours(Id, DateTime.Now);
            }
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
