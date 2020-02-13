using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.ObjectModel;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for ClientEditWin.xaml
    /// </summary>
    public partial class ClientEditWin : Window
    {
        Client ClientObject = new Client();

        public ClientEditWin(int ClientId)
        {
            InitializeComponent();

            using (var db = new PodaciContext())
            {
                ClientObject = db.Clients.Include(x => x.CleaningJobs).FirstOrDefault(x => x.Id == ClientId);
                dataGrid.ItemsSource = ClientObject.CleaningJobs;
            }
            this.DataContext = ClientObject;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "CleaningJob")
            {
                Fun.Delete(((Button)sender).DataContext, CleaningJobs: ClientObject.CleaningJobs);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PodaciContext())
            {
                var clean = db.Add(new CleaningJob { ClientId = ClientObject.Id, Date = DateTime.Now }).Entity;
                db.SaveChanges();
                ClientObject.CleaningJobs.Add(clean);
            }
        }



    }

    public class CleanersList : Dictionary<int, string>
    {
        public CleanersList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, null);
                var Cleaners = db.Cleaners;
                if (Cleaners != null && Cleaners.Any() )
                    foreach (var cleaner in Cleaners)
                        this.Add(cleaner.Id, cleaner.Name + " " + cleaner.Surname);

            }

        }
    }

    public class TeamsList : Dictionary<int, string>
    {
        public TeamsList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, null);
                var Teams = db.Teams;
                if (Teams != null && Teams.Any())
                    foreach (var team in Teams)
                        this.Add(team.Id, team.Name);

            }

        }
    }


}
