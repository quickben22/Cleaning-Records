using CleaningRecords.Moduli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Windows;

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

        private DateTime _HolidayStart;
        public DateTime HolidayStart { get { return _HolidayStart; } set { _HolidayStart = (value); this.OnPropertyChanged("HolidayStart"); } }
        private DateTime _HolidayEnd;
        public DateTime HolidayEnd { get { return _HolidayEnd; } set { _HolidayEnd = (value); this.OnPropertyChanged("HolidayEnd"); } }


        private DateTime _MondayStart2;
        public DateTime MondayStart2 { get { return _MondayStart2; } set { _MondayStart2 = (value); this.OnPropertyChanged("MondayStart2"); } }
        private DateTime _MondayEnd2;
        public DateTime MondayEnd2 { get { return _MondayEnd2; } set { _MondayEnd2 = (value); this.OnPropertyChanged("MondayEnd2"); } }
        private DateTime _TuesdayStart2;
        public DateTime TuesdayStart2 { get { return _TuesdayStart2; } set { _TuesdayStart2 = (value); this.OnPropertyChanged("TuesdayStart2"); } }

        private DateTime _TuesdayEnd2;
        public DateTime TuesdayEnd2 { get { return _TuesdayEnd2; } set { _TuesdayEnd2 = (value); this.OnPropertyChanged("TuesdayEnd2"); } }
        private DateTime _WednesdayStart2;
        public DateTime WednesdayStart2 { get { return _WednesdayStart2; } set { _WednesdayStart2 = (value); this.OnPropertyChanged("WednesdayStart2"); } }
        private DateTime _WednesdayEnd2;
        public DateTime WednesdayEnd2 { get { return _WednesdayEnd2; } set { _WednesdayEnd2 = (value); this.OnPropertyChanged("WednesdayEnd2"); } }
        private DateTime _ThursdayStart2;
        public DateTime ThursdayStart2 { get { return _ThursdayStart2; } set { _ThursdayStart2 = (value); this.OnPropertyChanged("ThursdayStart2"); } }
        private DateTime _ThursdayEnd2;
        public DateTime ThursdayEnd2 { get { return _ThursdayEnd2; } set { _ThursdayEnd2 = (value); this.OnPropertyChanged("ThursdayEnd2"); } }
        private DateTime _FridayStart2;
        public DateTime FridayStart2 { get { return _FridayStart2; } set { _FridayStart2 = (value); this.OnPropertyChanged("FridayStart2"); } }
        private DateTime _FridayEnd2;
        public DateTime FridayEnd2 { get { return _FridayEnd2; } set { _FridayEnd2 = (value); this.OnPropertyChanged("FridayEnd2"); } }
        private DateTime _SaturdayStart2;
        public DateTime SaturdayStart2 { get { return _SaturdayStart2; } set { _SaturdayStart2 = (value); this.OnPropertyChanged("SaturdayStart2"); } }
        private DateTime _SaturdayEnd2;
        public DateTime SaturdayEnd2 { get { return _SaturdayEnd2; } set { _SaturdayEnd2 = (value); this.OnPropertyChanged("SaturdayEnd2"); } }
        private DateTime _SundayStart2;
        public DateTime SundayStart2 { get { return _SundayStart2; } set { _SundayStart2 = (value); this.OnPropertyChanged("SundayStart2"); } }
        private DateTime _SundayEnd2;
        public DateTime SundayEnd2 { get { return _SundayEnd2; } set { _SundayEnd2 = (value); this.OnPropertyChanged("SundayEnd2"); } }
        private DateTime _NotAvailableStart2;
        public DateTime NotAvailableStart2 { get { return _NotAvailableStart2; } set { _NotAvailableStart2 = (value); this.OnPropertyChanged("NotAvailableStart2"); } }
        private DateTime _NotAvailableEnd2;
        public DateTime NotAvailableEnd2 { get { return _NotAvailableEnd2; } set { _NotAvailableEnd2 = (value); this.OnPropertyChanged("NotAvailableEnd2"); } }

        private DateTime _HolidayStart2;
        public DateTime HolidayStart2 { get { return _HolidayStart2; } set { _HolidayStart2 = (value); this.OnPropertyChanged("HolidayStart2"); } }
        private DateTime _HolidayEnd2;
        public DateTime HolidayEnd2 { get { return _HolidayEnd2; } set { _HolidayEnd2 = (value); this.OnPropertyChanged("HolidayEnd2"); } }

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
        private bool _Holiday;
        public bool Holiday { get { return _Holiday; } set { _Holiday = (value); this.OnPropertyChanged("Holiday"); } }

        private bool _Monday2;
        public bool Monday2 { get { return _Monday2; } set { _Monday2 = (value); this.OnPropertyChanged("Monday2"); } }
        private bool _Tuesday2;
        public bool Tuesday2 { get { return _Tuesday2; } set { _Tuesday2 = (value); this.OnPropertyChanged("Tuesday2"); } }
        private bool _Wednesday2;
        public bool Wednesday2 { get { return _Wednesday2; } set { _Wednesday2 = (value); this.OnPropertyChanged("Wednesday2"); } }
        private bool _Thursday2;
        public bool Thursday2 { get { return _Thursday2; } set { _Thursday2 = (value); this.OnPropertyChanged("Thursday2"); } }
        private bool _Friday2;
        public bool Friday2 { get { return _Friday2; } set { _Friday2 = (value); this.OnPropertyChanged("Friday2"); } }
        private bool _Saturday2;
        public bool Saturday2 { get { return _Saturday2; } set { _Saturday2 = (value); this.OnPropertyChanged("Saturday2"); } }
        private bool _Sunday2;
        public bool Sunday2 { get { return _Sunday2; } set { _Sunday2 = (value); this.OnPropertyChanged("Sunday2"); } }
        private bool _NotAvailable2;
        public bool NotAvailable2 { get { return _NotAvailable2; } set { _NotAvailable2 = (value); this.OnPropertyChanged("NotAvailable2"); } }
        private bool _Holiday2;
        public bool Holiday2 { get { return _Holiday2; } set { _Holiday2 = (value); this.OnPropertyChanged("Holiday2"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (prop == "Id")
            {
                HoursWeekly = Fun.GetCleanerHours(Id, DateTime.Now);
            }
            if (PropertyChanged != null)
            {



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
                    MessageBox.Show("Cleaner Update Error: " + ex.Message);
                }


                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }



    }
}
