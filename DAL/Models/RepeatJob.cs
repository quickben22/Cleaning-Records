using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class RepeatJob : INotifyPropertyChanged
    {

        public int Id { get; set; }


        private int _RepeatFrequency;
        public int RepeatFrequency { get { return _RepeatFrequency; } set { _RepeatFrequency = (value); this.OnPropertyChanged("RepeatFrequency"); } }



        public int AllDays { get; set; }


        private ObservableCollection<bool> _days;
        [NotMapped]
        public ObservableCollection<bool> days
        {
            get { return _days; }
            set { _days = (value); this.OnPropertyChanged("days"); }
        }

        //private bool _Monday;
        //public bool Monday { get { return _Monday; } set { _Monday = (value); this.OnPropertyChanged("Monday"); } }

        //private bool _Tuesday;
        //public bool Tuesday { get { return _Tuesday; } set { _Tuesday = (value); this.OnPropertyChanged("Tuesday"); } }

        //private bool _WednesDay;
        //public bool WednesDay { get { return _WednesDay; } set { _WednesDay = (value); this.OnPropertyChanged("WednesDay"); } }

        //private bool _Thursday;
        //public bool Thursday { get { return _Thursday; } set { _Thursday = (value); this.OnPropertyChanged("Thursday"); } }

        //private bool _Friday;
        //public bool Friday { get { return _Friday; } set { _Friday = (value); this.OnPropertyChanged("Friday"); } }

        //private bool _Saturday;
        //public bool Saturday { get { return _Saturday; } set { _Saturday = (value); this.OnPropertyChanged("Saturday"); } }

        //private bool _Sunday;
        //public bool Sunday { get { return _Sunday; } set { _Sunday = (value); this.OnPropertyChanged("Sunday"); } }



        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CleaningJob> CleaningJobs { get; set; }

        protected void OnPropertyChanged(string prop)
        {

    

            if (PropertyChanged != null)
            {

                //using (var db = new PodaciContext())
                //{
                //    db.Update(this);
                //    db.SaveChanges();
                //}

                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }

        public void daysToAllDays()
        {
            string bits = "";

            foreach (var bit in days)
            {
                if (bit)
                    bits += "1";
                else
                    bits += "0";
            }
            AllDays = Convert.ToInt32(bits, 2);
        }

        public void AllDaysToDays()
        {

            days = new ObservableCollection<bool> { false, false, false, false, false, false, false };

            string binary = Convert.ToString(AllDays, 2).PadLeft(7, '0');

            for (int i = 0; i < 7; i++)
            {
                days[i] = binary[i] == '1';
            }

        }


    }
}
