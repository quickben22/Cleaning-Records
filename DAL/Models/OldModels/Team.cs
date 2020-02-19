using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CleaningRecords.DAL.Models.OldModels
{
    public class Team : INotifyPropertyChanged
    {
  
        public int Id { get; set; }

        private bool _IsActive;
        public bool IsActive { get { return _IsActive; } set { _IsActive = (value); this.OnPropertyChanged("IsActive"); } }

        private string _Name;
        public string Name { get { return _Name; } set { _Name = (value); this.OnPropertyChanged("Name"); } }

        private string _Color;
        public string Color { get { return _Color; } set { _Color = (value); this.OnPropertyChanged("Color"); } }
        private ObservableCollection<CleanerTeam> _CleanerTeams;
        public ObservableCollection<CleanerTeam> CleanerTeams { get { return _CleanerTeams; } set { _CleanerTeams = (value); this.OnPropertyChanged("CleanerTeams"); } }
        public ObservableCollection<CleaningJob> CleaningJobs { get; set; }
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
