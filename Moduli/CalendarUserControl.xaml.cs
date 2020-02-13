using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using MonthCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CalendarUserControl.xaml
    /// </summary>
    public partial class CalendarUserControl : UserControl
    {

        private CalendarViewModel model;

        public CalendarUserControl()
        {
            InitializeComponent();
            Loaded += Window1_Loaded;
        }



        private void Window1_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Random rand = new Random(System.DateTime.Now.Second);

            //for (int i = 1; i <= 5; i++)
            //{
            //    Appointment apt = new Appointment();
            //    apt.CleaningJobID = i;
            //    apt.Date = new System.DateTime(System.DateTime.Now.Year, 2, 8);
            //    apt.Subject = "9:00 - 12:00 \n Marko Mesiček";
            //    _myAppointmentsList.Add(apt);
            //}

            model = new CalendarViewModel();
            this.DataContext = model;


            SetAppointments();
        }
        private void DayBoxDoubleClicked_event(NewAppointmentEventArgs e)
        {
            CalendarEditWin dlg = new CalendarEditWin(date: Convert.ToDateTime(e.StartDate));

            dlg.ShowDialog();
            SetAppointments();
            //MessageBox.Show("You double-clicked on day " + Convert.ToDateTime(e.StartDate).ToShortDateString(), "Calendar Event", MessageBoxButton.OK);
        }

        private void AppointmentDblClicked(int CleaningJobID)
        {
            CalendarEditWin dlg = new CalendarEditWin(CleaningJobId: CleaningJobID);
            dlg.ShowDialog();
            SetAppointments();
            //MessageBox.Show("You double-clicked on appointment with ID = " + CleaningJobID, "Calendar Event", MessageBoxButton.OK);
        }

        private void DisplayMonthChanged(MonthChangedEventArgs e)
        {
            SetAppointments();
        }

        private void SetAppointments()
        {


            List<Appointment> _myAppointmentsList = new List<Appointment>();
            using (var db = new PodaciContext())
            {
           
                var jobs = db.CleaningJobs
                    .Include(x => x.Client)
                    .Include(x => x.Team)
                    .ThenInclude(x => x.CleanerTeams)
                    .ThenInclude(y => y.Cleaner)
                    .Include(x => x.Cleaner)
                    .Where(x => x.Date.Month == this.AptCalendar.DisplayStartDate.Month).ToList();

                if (model.TeamId != null && model.TeamId != 0)
                    jobs = jobs.Where(x => x.TeamId == model.TeamId)?.ToList();

                if (model.CleanerId != null && model.CleanerId!=0)
                    jobs = jobs.Where(x => x.CleanerId == model.CleanerId || x.Team?.CleanerTeams?.FirstOrDefault(y => y.CleanerId == model.CleanerId) != null)?.ToList();

                foreach (var job in jobs)
                {
                    Appointment apt = new Appointment();
                    apt.CleaningJobID = job.Id;
                    apt.Date = job.Date;
                    string cleaner = "";
                    if (job.Cleaner != null)
                    {
                        apt.CleanerID = (int)job.CleanerId;
                        cleaner = job.Cleaner.Name + " " + job.Cleaner.Surname;
                    }
                    if (job.TeamId != null)
                    {
                        if (model.CleanerId != null)
                        {
                            var c = job.Team?.CleanerTeams?.FirstOrDefault(x => x.CleanerId == model.CleanerId)?.Cleaner;
                            cleaner = c?.Name + " " + c?.Surname;
                            apt.CleanerID = c.Id;
                        }
                        else
                        {
                            cleaner = job.Team.Name;
                            apt.TeamID = (int)job.TeamId;
                        }
                    }
                    apt.Subject = $"{job.TimeStart.ToString("H:mm")} - {job.TimeEnd.ToString("H:mm")} \n {job.Client.Name} {job.Client.Surname}\n {cleaner }  ";
                    _myAppointmentsList.Add(apt);
                }
            }

            AptCalendar.MonthAppointments = _myAppointmentsList.FindAll(new System.Predicate<Appointment>((Appointment apt) => apt.Date != null && Convert.ToDateTime(apt.Date).Month == this.AptCalendar.DisplayStartDate.Month && Convert.ToDateTime(apt.Date).Year == this.AptCalendar.DisplayStartDate.Year));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e?.AddedItems != null && e.AddedItems.Count > 0)
            {
                SetAppointments();
            }
        }
    }
}
