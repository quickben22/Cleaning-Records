using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CleaningRecords.DAL.Models.OldModels
{
    public class Client : INotifyPropertyChanged
    {

        public Client()
        {
            _Locations = new Dictionary<int, string>();
        }



        private int _Id;
        public int Id { get { return _Id; } set { _Id = (value); this.OnPropertyChanged("Id"); } }

        private bool _IsActive;
        public bool IsActive { get { return _IsActive; } set { _IsActive = (value); this.OnPropertyChanged("IsActive"); } }

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

        private int _ClientStatus;
        public int ClientStatus { get { return _ClientStatus; } set { _ClientStatus = (value); this.OnPropertyChanged("ClientStatus"); } }




        private ObservableCollection<CleaningJob> _CleaningJobs;
        public ObservableCollection<CleaningJob> CleaningJobs { get { return _CleaningJobs; } set { _CleaningJobs = (value); this.OnPropertyChanged("CleaningJobs"); } }


        private Dictionary<int, string> _Locations;
        [NotMapped]
        public Dictionary<int, string> Locations { get { return _Locations; } set { _Locations = (value); this.OnPropertyChanged("Locations"); } }


        private Dictionary<int, string> _Months;
        [NotMapped]
        public Dictionary<int, string> Months { get { return _Months; } set { _Months = (value); this.OnPropertyChanged("Months"); } }

        private ObservableCollection<int> _Years;
        [NotMapped]
        public ObservableCollection<int> Years { get { return _Years; } set { _Years = (value); this.OnPropertyChanged("Years"); } }


        private int? _Month;
        [NotMapped]
        public int? Month { get { return _Month; } set { _Month = (value); this.OnPropertyChanged("Month"); } }

        private int? _Year;
        [NotMapped]
        public int? Year { get { return _Year; } set { _Year = (value); this.OnPropertyChanged("Year"); } }


        private int? _Cleaner;
        [NotMapped]
        public int? Cleaner { get { return _Cleaner; } set { _Cleaner = (value); this.OnPropertyChanged("Cleaner"); } }

        private int? _Status;
        [NotMapped]
        public int? Status { get { return _Status; } set { _Status = (value); this.OnPropertyChanged("Status"); } }
        private int? _Service;
        [NotMapped]
        public int? Service { get { return _Service; } set { _Service = (value); this.OnPropertyChanged("Service"); } }



        public event PropertyChangedEventHandler PropertyChanged;

        public void setMonthsYears()
        {
            var year = DateTime.Now.Year;
            List<int> years = new List<int>();
            for (int i = year - 10; i < year + 10; i++)
                years.Add(i);
            Years = new ObservableCollection<int>(years);
            Months = new Dictionary<int, string> { {1,"January" }, {2,"February" }, {3,"March" },
                {4,"April" }, {5,"May" }, {6,"June" }, {7,"July" },{8, "August" }, {9,"September" },
                {10,"October" }, {11,"November" }, {12,"December" } };

            Year = year;
            Month = DateTime.Now.Month;

        }
        public void setLocations()
        {

            Locations = new Dictionary<int, string> { { 0, Address }, { 1, Address2 }, { 2, Address3 }, { 3, Address4 } };
            //if (Address != null)
            //    Locations.Add(Address);
            //if (Address2 != null)
            //    Locations.Add(Address2);
            //if (Address3 != null)
            //    Locations.Add(Address3);
            //if (Address4 != null)
            //    Locations.Add( Address4);

        }

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
