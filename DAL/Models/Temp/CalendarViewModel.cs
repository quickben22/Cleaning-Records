using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CalendarViewModel : INotifyPropertyChanged
    {



        private int? _CleanerId;
        public int? CleanerId { get { return _CleanerId; } set { _CleanerId = (value); this.OnPropertyChanged("CleanerId"); } }



        private int? _TeamId;
        public int? TeamId { get { return _TeamId; } set { _TeamId = (value); this.OnPropertyChanged("TeamId"); } }


        private int? _ClientId;
        public int? ClientId { get { return _ClientId; } set { _ClientId = (value); this.OnPropertyChanged("ClientId"); } }

        private double _Week1;
        public double Week1 { get { return _Week1; } set { _Week1 = (value); this.OnPropertyChanged("Week1"); } }


        private double _Week2;
        public double Week2 { get { return _Week2; } set { _Week2 = (value); this.OnPropertyChanged("Week2"); } }



        private double _Week3;
        public double Week3 { get { return _Week3; } set { _Week3 = (value); this.OnPropertyChanged("Week3"); } }


        private double _Week4;
        public double Week4 { get { return _Week4; } set { _Week4 = (value); this.OnPropertyChanged("Week4"); } }

        private double _Week5;
        public double Week5 { get { return _Week5; } set { _Week5 = (value); this.OnPropertyChanged("Week5"); } }



        private string _Monday;
        public string Monday { get { return _Monday; } set { _Monday = (value); this.OnPropertyChanged("Monday"); } }
        private string _Tuesday;
        public string Tuesday { get { return _Tuesday; } set { _Tuesday = (value); this.OnPropertyChanged("Tuesday"); } }
        private string _Wednesday;
        public string Wednesday { get { return _Wednesday; } set { _Wednesday = (value); this.OnPropertyChanged("Wednesday"); } }
        private string _Thursday;
        public string Thursday { get { return _Thursday; } set { _Thursday = (value); this.OnPropertyChanged("Thursday"); } }
        private string _Friday;
        public string Friday { get { return _Friday; } set { _Friday = (value); this.OnPropertyChanged("Friday"); } }
        private string _Saturday;
        public string Saturday { get { return _Saturday; } set { _Saturday = (value); this.OnPropertyChanged("Saturday"); } }
        private string _Sunday;
        public string Sunday { get { return _Sunday; } set { _Sunday = (value); this.OnPropertyChanged("Sunday"); } }

        private string _NotAvailable;
        public string NotAvailable { get { return _NotAvailable; } set { _NotAvailable = (value); this.OnPropertyChanged("NotAvailable"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {

                if (prop == "TeamId" && TeamId != null && CleanerId != 0)
                    CleanerId = 0;
                else if (prop == "CleanerId" && CleanerId != null && TeamId != 0)
                    TeamId = 0;


                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }
    }
}
