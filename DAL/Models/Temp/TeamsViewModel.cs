using Microsoft.EntityFrameworkCore;
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

        private string _Name;
        public string Name { get { return _Name; } set { _Name = (value); this.OnPropertyChanged("Name"); } }

        private string _Color;
        public string Color { get { return _Color; } set { _Color = (value); this.OnPropertyChanged("Color"); } }

        private int? _CleanerId;
        public int? CleanerId { get { return _CleanerId; } set { _CleanerId = (value); this.OnPropertyChanged("CleanerId"); } }

        private int? _Cleaner2Id;
        public int? Cleaner2Id { get { return _Cleaner2Id; } set { _Cleaner2Id = (value); this.OnPropertyChanged("Cleaner2Id"); } }
        private int? _Cleaner3Id;
        public int? Cleaner3Id { get { return _Cleaner3Id; } set { _Cleaner3Id = (value); this.OnPropertyChanged("Cleaner3Id"); } }
        private int? _Cleaner4Id;
        public int? Cleaner4Id { get { return _Cleaner4Id; } set { _Cleaner4Id = (value); this.OnPropertyChanged("Cleaner4Id"); } }
        private int? _Cleaner5Id;
        public int? Cleaner5Id { get { return _Cleaner5Id; } set { _Cleaner5Id = (value); this.OnPropertyChanged("Cleaner5Id"); } }
        private int? _Cleaner6Id;
        public int? Cleaner6Id { get { return _Cleaner6Id; } set { _Cleaner6Id = (value); this.OnPropertyChanged("Cleaner6Id"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {


                if (prop == "Name")
                {
                    Team.Name = Name;
                    using (var db = new PodaciContext())
                    {
                        db.Update(Team);
                        db.SaveChanges();
                    }

                }
                else if (prop == "Color")
                {
                    Team.Color = Color;
                    using (var db = new PodaciContext())
                    {
                        db.Update(Team);
                        db.SaveChanges();
                    }

                }
                else
                {
                    bool flag = true;
                    List<int> Cleaners = new List<int>();
                    if (CleanerId != null)
                    {
                        if (Cleaners.Contains((int)CleanerId))
                            flag = false;
                        Cleaners.Add((int)CleanerId);

                    }
                    if (Cleaner2Id != null)
                    {
                        if (Cleaners.Contains((int)Cleaner2Id))
                            flag = false;
                        Cleaners.Add((int)Cleaner2Id);
                    }
                    if (Cleaner3Id != null)
                    {
                        if (Cleaners.Contains((int)Cleaner3Id))
                            flag = false;
                        Cleaners.Add((int)Cleaner3Id);
                    }
                    if (Cleaner4Id != null)
                    {
                        if (Cleaners.Contains((int)Cleaner4Id))
                            flag = false;
                        Cleaners.Add((int)Cleaner4Id);
                    }
                    if (Cleaner5Id != null)
                    {
                        if (Cleaners.Contains((int)Cleaner5Id))
                            flag = false;
                        Cleaners.Add((int)Cleaner5Id);
                    }
                    if (Cleaner6Id != null)
                    {
                        if (Cleaners.Contains((int)Cleaner6Id))
                            flag = false;
                        Cleaners.Add((int)Cleaner6Id);
                    }




                    if (flag)
                    {
                        using (var db = new PodaciContext())
                        {

                            List<CleanerTeam> toRemove = new List<CleanerTeam>();
                            for (int i = 0; i < Team.CleanerTeams?.Count(); i++)
                            {
                                if (!Cleaners.Contains(Team.CleanerTeams[i].CleanerId))
                                {
                                    toRemove.Add(Team.CleanerTeams[i]);
                                }
                            }


                            if (toRemove.Count > 0)
                            {
                                foreach (var CleanerTeam in toRemove)
                                {
                                    db.Remove(CleanerTeam);
                                    Team.CleanerTeams.Remove(CleanerTeam);
                                }
                                db.SaveChanges();
                            }


                            flag = false;
                            foreach (int CleanerId in Cleaners)
                            {
                                if (CleanerId != 0 && !Team.CleanerTeams.Any(x => x.CleanerId == CleanerId))
                                {
                                    var CleanerTeam = new CleanerTeam { CleanerId = CleanerId, TeamId = Team.Id };
                                    db.Add(CleanerTeam);
                                    Team.CleanerTeams.Add(CleanerTeam);
                                    flag = true;
                                }
                            }
                            if (flag)
                                db.SaveChanges();

                            //if (Cleaners.Count < Team.CleanerTeams?.Count())
                            //{
                            //    var cleanersTemp = Team.CleanerTeams.Select(x => x.CleanerId)?.ToList();

                            //    foreach (var CleanId in cleanersTemp)
                            //    {
                            //        if (Cleaners.Count == 0 || !Cleaners.Contains(CleanId))
                            //        {
                            //            db.Remove(CleanId);
                            //            db.SaveChanges();

                            //        }
                            //    }


                            //}
                            //else if (Cleaners.Count >= Team.CleanerTeams?.Count())
                            //{
                            //    var cleanersTemp = Team.CleanerTeams.Select(x => x.CleanerId)?.ToList();

                            //    flag = false;
                            //    List<int> cleanerIds = new List<int>();
                            //    foreach (var CleanId in Cleaners)
                            //    {
                            //        if (cleanersTemp == null || !cleanersTemp.Contains(CleanId))
                            //        {
                            //            cleanerIds.Add(CleanId);
                            //            flag = true;

                            //        }
                            //    }

                            //    if (flag)
                            //    {
                            //        int j = 0;
                            //        for (int i = 0; i < Team.CleanerTeams?.Count(); i++)
                            //        {
                            //            if (!Cleaners.Contains(Team.CleanerTeams[i].CleanerId))
                            //            {
                            //                db.Remove(Team.CleanerTeams[i]);
                            //                db.SaveChanges();
                            //                db.Add(new CleanerTeam { CleanerId = cleanerIds[j], TeamId = Team.Id });
                            //                db.SaveChanges();
                            //                Team.CleanerTeams[i].CleanerId = cleanerIds[j];
                            //                j++;
                            //            }
                            //        }
                            //        if (Cleaners.Count > Team.CleanerTeams?.Count())
                            //        {
                            //            for (int i = Team.CleanerTeams.Count(); i < Cleaners.Count; i++)
                            //            {
                            //                var cleanTeam = new CleanerTeam { CleanerId = cleanerIds[j], TeamId = Team.Id };
                            //                Team.CleanerTeams.Add(cleanTeam);
                            //                db.Add(cleanTeam);
                            //                db.SaveChanges();
                            //                j++;
                            //            }
                            //        }

                            //    }
                            //}






                        }
                    }
                }

                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }


    }
}
