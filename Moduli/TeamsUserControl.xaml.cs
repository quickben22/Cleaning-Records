using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for TeamsUserControl.xaml
    /// </summary>
    public partial class TeamsUserControl : UserControl
    {

        TeamsViewModel Teams = new TeamsViewModel();
        public TeamsUserControl()
        {
            InitializeComponent();

            using (var db = new PodaciContext())
            {
                Teams.Teams = new ObservableCollection<TeamsHelper>();

                foreach (var team in db.Teams
                    .Include(x => x.CleanerTeams)
                    .ThenInclude(x => x.Cleaner))
                {
                    var th = new TeamsHelper { Team = team, Name = team.Name };

                    if (team.CleanerTeams?.Count > 0)
                        th.CleanerId = team.CleanerTeams[0].CleanerId;
                    if (team.CleanerTeams?.Count > 1)
                        th.Cleaner2Id = team.CleanerTeams[1].CleanerId;
                    if (team.CleanerTeams?.Count > 2)
                        th.Cleaner2Id = team.CleanerTeams[2].CleanerId;
                    if (team.CleanerTeams?.Count > 3)
                        th.Cleaner2Id = team.CleanerTeams[3].CleanerId;
                    if (team.CleanerTeams?.Count > 4)
                        th.Cleaner2Id = team.CleanerTeams[4].CleanerId;

                    Teams.Teams.Add(th);

                }

                dataGrid.ItemsSource = Teams.Teams;

            }
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PodaciContext())
            {
                var team = db.Add(new Team()).Entity;
                team.CleanerTeams = new ObservableCollection<CleanerTeam>();
                db.SaveChanges();
                Teams.Teams.Add(new TeamsHelper { Team = team });
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "TeamsHelper")
            {
                Fun.Delete(((Button)sender).DataContext, TeamsHelpers: Teams.Teams);
            }
        }
    }



}
