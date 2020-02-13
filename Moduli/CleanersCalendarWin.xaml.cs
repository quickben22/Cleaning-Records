using CleaningRecords.DAL;
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
using System.Windows.Shapes;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for CleanersCalendarWin.xaml
    /// </summary>
    public partial class CleanersCalendarWin : Window
    {
        public CleanersCalendarWin()
        {
            InitializeComponent();
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
                var jobs = db.CleaningJobs.Include(x => x.Client).Where(x => x.Date.Month == this.AptCalendar.DisplayStartDate.Month).ToList();

                foreach (var job in jobs)
                {
                    Appointment apt = new Appointment();
                    apt.CleaningJobID = job.Id;
                    apt.Date = job.Date;
                    apt.Subject = $"{job.TimeStart.ToString("H:mm")} - {job.TimeEnd.ToString("H:mm")} \n {job.Client.Name} {job.Client.Surname}";
                    _myAppointmentsList.Add(apt);
                }
            }

            AptCalendar.MonthAppointments = _myAppointmentsList.FindAll(new System.Predicate<Appointment>((Appointment apt) => apt.Date != null && Convert.ToDateTime(apt.Date).Month == this.AptCalendar.DisplayStartDate.Month && Convert.ToDateTime(apt.Date).Year == this.AptCalendar.DisplayStartDate.Year));
        }

    }
}
