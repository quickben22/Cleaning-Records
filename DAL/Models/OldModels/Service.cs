using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace CleaningRecords.DAL.Models.OldModels
{
    public class Service : INotifyPropertyChanged
    {

        public int Id { get; set; }
        private string _Name;
        public string Name { get { return _Name; } set { _Name = (value); this.OnPropertyChanged("Name"); } }

        private string _Description;
        public string Description { get { return _Description; } set { _Description = (value); this.OnPropertyChanged("Description"); } }

        private double _Rate;
        public double Rate { get { return _Rate; } set { _Rate = (value); this.OnPropertyChanged("Rate"); } }

        private double _Cost;
        public double Cost { get { return _Cost; } set { _Cost = (value); this.OnPropertyChanged("Cost"); } }

        private int _ServiceStatus;
        public int ServiceStatus { get { return _ServiceStatus; } set { _ServiceStatus = (value); this.OnPropertyChanged("ServiceStatus"); } }


        private string _Color;
        public string Color { get { return _Color; } set { _Color = (value); this.OnPropertyChanged("Color"); } }

        public ObservableCollection<CleaningJob> CleaningJobs { get; set; }

        public List<ServiceJob> ServiceJobs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
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
                    MessageBox.Show("Service Update Error: " + ex.Message);
                }


                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }

    }
}
