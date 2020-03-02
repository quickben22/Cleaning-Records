using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        Dictionary<int, int> repeatJobs = new Dictionary<int, int>();
        public CalendarEditWin(int? CleaningJobId = null, DateTime? date = null)
        {
            InitializeComponent();

            if (CleaningJobId != null)
            {
                using (var db = new PodaciContext())
                {
                    model.CleaningJobs = new ObservableCollection<CleaningJob>(
                        db.CleaningJobs
                        .Include(x => x.RepeatJob)
                        .Where(x => x.Id == CleaningJobId)
                        );
                    dataGrid.ItemsSource = model.CleaningJobs;
                    Date = model.CleaningJobs.FirstOrDefault()?.Date;
                }
            }
            else if (date != null)
            {
                Date = date;
                using (var db = new PodaciContext())
                {
                    model.CleaningJobs = new ObservableCollection<CleaningJob>(db.CleaningJobs.Include(x => x.RepeatJob).Where(x => x.Date.Date == date.Value.Date));
                    dataGrid.ItemsSource = model.CleaningJobs;
                }
            }

            foreach (var cj in model.CleaningJobs)
            {
                if (cj.RepeatJobId != null)
                    repeatJobs.Add(cj.Id, (int)cj.RepeatJobId);
            }



        }

        protected override void OnClosing(CancelEventArgs e)
        {

            Fun.overWorked(model.CleaningJobs);
            foreach (var cj in model.CleaningJobs)
            {
                if (repeatJobs.ContainsKey(cj.Id) && cj.RepeatJobId != null)
                {

                    if (cj.changed)
                    {
                        OnlyThisShiftDlg dlg = new OnlyThisShiftDlg();
                        if (dlg.ShowDialog() == true)
                        {
                            cj.RepeatJob = null;
                            cj.RepeatJobId = null;
                            using (var db = new PodaciContext())
                            {
                                db.Update(cj);
                                db.SaveChanges();
                            }

                        }
                        else
                            Fun.setRepeatingJobs(repeatJobs[cj.Id], cj);

                    }


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

        private void RepeatEdit_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "CleaningJob")
            {
                CleaningJobRepeatWin dlg = new CleaningJobRepeatWin(((CleaningJob)((Button)sender).DataContext).Id);
                dlg.ShowDialog();
                if (dlg.Ok)
                    Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "CleaningJob")
            {
                ExtraServicesWin dlg = new ExtraServicesWin(((CleaningJob)((Button)sender).DataContext).Id);
                if (dlg.ShowDialog() == true)
                    ((CleaningJob)((Button)sender).DataContext).ConvertAmount();
            }
        }
    }

}
