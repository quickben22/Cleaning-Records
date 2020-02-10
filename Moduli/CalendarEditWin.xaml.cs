using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for CalendarEditWin.xaml
    /// </summary>
    public partial class CalendarEditWin : Window
    {


        CalendarEditViewModel model = new CalendarEditViewModel();
        DateTime? Date;
        
        public CalendarEditWin(int? CleaningJobId = null, DateTime? date = null)
        {
            InitializeComponent();

            if (CleaningJobId != null)
            {
                using (var db = new PodaciContext())
                {
                    model.CleaningJobs = new ObservableCollection<CleaningJob>(db.CleaningJobs.Where(x => x.Id == CleaningJobId));
                    dataGrid.ItemsSource = model.CleaningJobs;
                    Date = model.CleaningJobs.FirstOrDefault()?.Date;
                }
            }
            else if (date != null)
            {
                Date = date;
                using (var db = new PodaciContext())
                {
                    model.CleaningJobs = new ObservableCollection<CleaningJob>(db.CleaningJobs.Where(x => x.Date.Date == date.Value.Date));
                    dataGrid.ItemsSource = model.CleaningJobs;
                }
            }


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "CleaningJob")
            {
                Fun.Delete(((Button)sender).DataContext, CleaningJobs: model.CleaningJobs);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PodaciContext())
            {
                var clean = db.Add(new CleaningJob { ClientId = 1, Date = Date ?? DateTime.Now }).Entity;
                db.SaveChanges();
                model.CleaningJobs.Add(clean);
            }
        }
    }
    public class ClientsList : Dictionary<int, string>
    {
        public ClientsList()
        {
            using (var db = new PodaciContext())
            {
                var Clients = db.Clients;
                foreach (var client in Clients)
                    this.Add(client.Id, client.Name + " " + client.Surname);

            }

        }
    }
}
