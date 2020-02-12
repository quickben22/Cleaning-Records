using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CleaningRecords.DAL.Models
{


    public class TeamsViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<TeamsHelper> _Teams;
        public ObservableCollection<TeamsHelper> Teams { get { return _Teams; } set { _Teams = (value); this.OnPropertyChanged("Teams"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

            }
        }

    }

    public class TeamsHelper : INotifyPropertyChanged
    {

        public Team Team { get; set; }

        private string? _Name;
        public string Name { get { return _Name; } set { _Name = (value); this.OnPropertyChanged("Name"); } }

        private int? _CleanerId;
        public int? CleanerId { get { return _CleanerId; } set { _CleanerId = (value); this.OnPropertyChanged("CleanerId"); } }

        private int? _Cleaner2Id;
        public int? Cleaner2Id { get { return _Cleaner2Id; } set { _Cleaner2Id = (value); this.OnPropertyChanged("Cleaner2Id"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {


                if (prop == "Name")
                    Team.Name = Name;
                else
                {

                    if (CleanerId != null && CleanerId != 0 && !Team.CleanerTeams.Any(x => x.CleanerId == CleanerId))
                    {

                        if (Team.CleanerTeams?.Count() > 0)
                              Team.CleanerTeams[0].CleanerId = (int)CleanerId;
                         else
                            Team.CleanerTeams.Add(new CleanerTeam { CleanerId = (int)CleanerId, TeamId = Team.Id });
                    }
                    if (Cleaner2Id != null && Cleaner2Id != 0 && !Team.CleanerTeams.Any(x => x.CleanerId == Cleaner2Id))
                    {
                        if (Team.CleanerTeams?.Count() > 1)
                              Team.CleanerTeams[0].CleanerId = (int)CleanerId;
                         else
                            Team.CleanerTeams.Add(new CleanerTeam { CleanerId = (int)Cleaner2Id, TeamId = Team.Id });

                    }
                  
                  


                }
                using (var db = new PodaciContext())
                {
                    db.UpdateRange(this.Team.CleanerTeams);
                    db.SaveChanges();
                }

                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }

    }

}
