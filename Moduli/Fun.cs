using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using CleaningRecords.Global;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CleaningRecords.Moduli
{
    public static class Fun
    {
        public static void Delete(object Object, ObservableCollection<Client> Clients = null,
            ObservableCollection<CleaningJob> CleaningJobs = null, ObservableCollection<Cleaner> Cleaners = null,
            ObservableCollection<TeamsHelper> TeamsHelpers = null, ObservableCollection<Service> Services = null)
        {
            var messageBoxText = "Delete this item?";

            string caption = "Confirm Deletion";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.OK:
                    {

                        try
                        {

                            using (var db = new PodaciContext())
                            {
                                if (Object.GetType().Name == "TeamsHelper")
                                {
                                    try
                                    {
                                        db.Remove(((TeamsHelper)Object).Team);
                                        db.SaveChanges();
                                        TeamsHelpers.Remove((TeamsHelper)Object);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Not possible to delete Team while it has cleaning jobs allocated!", "Delete no possible", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }
                                }


                                if (Object.GetType().Name == "Client")
                                {
                                    var client = db.Clients.Include(x => x.CleaningJobs).FirstOrDefault();

                                    if (client.CleaningJobs?.Count > 0)
                                    {
                                        MessageBox.Show("Not possible to delete Client while he has cleaning jobs allocated to him!", "Delete no possible", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }
                                    else
                                    {

                                        db.Remove(Object);
                                        db.SaveChanges();
                                        Clients.Remove((Client)Object);
                                    }
                                }
                                if (Object.GetType().Name == "CleaningJob")
                                {

                                    db.Remove(Object);
                                    db.SaveChanges();
                                    CleaningJobs.Remove((CleaningJob)Object);
                                }
                                if (Object.GetType().Name == "Service")
                                {

                                    db.Remove(Object);
                                    db.SaveChanges();
                                    Services.Remove((Service)Object);
                                }
                                if (Object.GetType().Name == "Cleaner")
                                {
                                    try
                                    {

                                        db.Remove(Object);
                                        db.SaveChanges();
                                        Cleaners.Remove((Cleaner)Object);
                                    }

                                    catch
                                    {
                                        MessageBox.Show("Not possible to delete Cleaner while he has cleaning jobs allocated!", "Delete no possible", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }
                                }

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting!", "Delete no possible", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {

                        break;
                    }
            }

        }

        public static void RefreshCombo(object c)
        {
            if (((ComboBox)c).ItemsSource.GetType().Name == "ClientsList")
                ((ComboBox)c).ItemsSource = new ClientsList();
            if (((ComboBox)c).ItemsSource.GetType().Name == "CleanersList")
                ((ComboBox)c).ItemsSource = new CleanersList();
            if (((ComboBox)c).ItemsSource.GetType().Name == "ClientsWithNullList")
                ((ComboBox)c).ItemsSource = new ClientsWithNullList();
            if (((ComboBox)c).ItemsSource.GetType().Name == "TeamsList")
                ((ComboBox)c).ItemsSource = new TeamsList();
            if (((ComboBox)c).ItemsSource.GetType().Name == "TeamsWithAllList")
                ((ComboBox)c).ItemsSource = new TeamsWithAllList();
            if (((ComboBox)c).ItemsSource.GetType().Name == "CleanersWithAllList")
                ((ComboBox)c).ItemsSource = new CleanersWithAllList();
        }


        public static double GetCleanerHours(int CleanerId, DateTime date)
        {
            double HoursWeekly = 0;
            using (var db = new PodaciContext())
            {

                var year = date.Year;
                var week = getWeek(date);

                var jobs = db.CleaningJobs
                    .Include(x => x.Team)
                    .ThenInclude(y => y.CleanerTeams)
                    .Where(x => (x.CleanerId == CleanerId || x.Team.CleanerTeams.Any(y => y.CleanerId == CleanerId)) && x.Week == week && x.Date.Year == year).ToList();



                var hours = jobs?.Select(x => x.NoOfHours);

                if (hours != null && hours.Count() > 0)
                {
                    foreach (var hour in jobs.Select(x => x.NoOfHours))
                        HoursWeekly += hour;
                }
            }

            return HoursWeekly;
        }
        static CultureInfo myCI = new CultureInfo("en-US");
        static System.Globalization.Calendar myCal = myCI.Calendar;
        public static int getWeek(DateTime date)
        {

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = DayOfWeek.Monday;//  myCI.DateTimeFormat.FirstDayOfWeek;

            var week = myCal.GetWeekOfYear(date, myCWR, myFirstDOW);

            return week;

        }




        public static int getDay(DateTime date)
        {

            var d = (((int)date.DayOfWeek == 0) ? 7 : (int)date.DayOfWeek) - 1;

            return d;

        }




        public static void overWorked(ObservableCollection<CleaningJob> CleaningJobs)
        {
            try
            {
                List<string> busy = new List<string>();
                foreach (var job in CleaningJobs)
                {

                    if (job.CleanerId != null && job.CleanerId != 0 && job.CleanerId != -1 && !busy.Contains(job.CleanerId + "," + job.Week))
                    {

                        var HoursWeekly = GetCleanerHours((int)job.CleanerId, job.Date);

                        if (HoursWeekly >= 18)
                        {
                            using (var db = new PodaciContext())
                            {
                                var cleaner = db.Cleaners.FirstOrDefault(x => x.Id == (int)job.CleanerId);
                                MessageBox.Show($"Warning! {cleaner?.Name} {cleaner?.Surname} has {HoursWeekly} hours a week (on week {job.Week})!", "Possible cleaner over worked!", MessageBoxButton.OK, MessageBoxImage.Warning);
                                busy.Add(job.CleanerId + "," + job.Week);
                            }

                        }
                    }
                    workerBusy(job);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OverWorked error: " + ex.Message);
            }

        }

        public static void workerBusy(CleaningJob job)
        {

            var cleaner = job.Cleaner;
            if (cleaner == null)
            {
                if (job.CleanerId != null && job.CleanerId != 0 && job.CleanerId != -1)
                    using (var db = new PodaciContext())
                        cleaner = db.Cleaners.FirstOrDefault(x => x.Id == job.CleanerId);
            }
            if (cleaner == null)
                return;

            var Days = new bool[] { cleaner.Monday, cleaner.Tuesday, cleaner.Wednesday, cleaner.Thursday, cleaner.Friday, cleaner.Saturday, cleaner.Sunday };
            var Days2 = new bool[] { cleaner.Monday2, cleaner.Tuesday2, cleaner.Wednesday2, cleaner.Thursday2, cleaner.Friday2, cleaner.Saturday2, cleaner.Sunday2 };
            var DaysStart = new DateTime[] { cleaner.MondayStart, cleaner.TuesdayStart, cleaner.WednesdayStart, cleaner.ThursdayStart, cleaner.FridayStart, cleaner.SaturdayStart, cleaner.SundayStart };
            var DaysEnd = new DateTime[] { cleaner.MondayEnd, cleaner.TuesdayEnd, cleaner.WednesdayEnd, cleaner.ThursdayEnd, cleaner.FridayEnd, cleaner.SaturdayEnd, cleaner.SundayEnd };
            var DaysStart2 = new DateTime[] { cleaner.MondayStart2, cleaner.TuesdayStart2, cleaner.WednesdayStart2, cleaner.ThursdayStart2, cleaner.FridayStart2, cleaner.SaturdayStart2, cleaner.SundayStart2 };
            var DaysEnd2 = new DateTime[] { cleaner.MondayEnd2, cleaner.TuesdayEnd2, cleaner.WednesdayEnd2, cleaner.ThursdayEnd2, cleaner.FridayEnd2, cleaner.SaturdayEnd2, cleaner.SundayEnd2 };
            if (!(job.Day > 0))
                return;
            if (!Days[job.Day])
            {
                MessageBox.Show($"Warning! Cleaner {cleaner.Name} {cleaner.Surname} not available {ZP.days[job.Day]}!");
                return;
            }

            var zeroTime = new DateTime(2020, 1, 1).TimeOfDay;

            if (job.TimeStart.TimeOfDay == zeroTime && job.TimeStart.TimeOfDay == zeroTime)
                return;

            if (job.TimeStart.TimeOfDay >= DaysStart[job.Day].TimeOfDay && job.TimeStart.TimeOfDay <= DaysEnd[job.Day].TimeOfDay
              && job.TimeEnd.TimeOfDay >= DaysStart[job.Day].TimeOfDay && job.TimeEnd.TimeOfDay <= DaysEnd[job.Day].TimeOfDay)
                return;

            if (Days2[job.Day])
            {
                if (job.TimeStart.TimeOfDay >= DaysStart2[job.Day].TimeOfDay && job.TimeStart.TimeOfDay <= DaysEnd2[job.Day].TimeOfDay
         && job.TimeEnd.TimeOfDay >= DaysStart2[job.Day].TimeOfDay && job.TimeEnd.TimeOfDay <= DaysEnd2[job.Day].TimeOfDay)
                    return;
            }

            MessageBox.Show($"Warning! Cleaner {cleaner.Name} {cleaner.Surname} not available {ZP.days[job.Day]} between hours of {job.TimeStart.ToString("HH:mm")} - {job.TimeEnd.ToString("HH:mm")}!");






        }


        public static void setRepeatingJobs(int RepeatJobId, CleaningJob CleaningJobCopy)
        {
            try
            {

                if (RepeatJobId == 0)
                    return;

                int iterations = 50;

                var date = CleaningJobCopy.Date;

                using (var db = new PodaciContext())
                {
                    var RepeatJob = db.RepeatJobs.Include(x => x.CleaningJobs).FirstOrDefault(x => x.Id == RepeatJobId);

                    RepeatJob.AllDaysToDays();
                    //var defaultCleanJob = RepeatJob.CleaningJobs.FirstOrDefault();
                    int week = getWeek(date);

                    int year = date.Year;



                    int maxWeek = getWeek(new DateTime(year, 12, 31));
                    List<int> weeks = new List<int> { week };

                    for (int i = 0; i < iterations; i++)
                    {
                        weeks.Add((weeks[i] + RepeatJob.RepeatFrequency) % (maxWeek + 1));
                    }
                    List<CleaningJob> toRemove = new List<CleaningJob>();
                    foreach (var cleanJob in RepeatJob.CleaningJobs)
                    {
                        if (cleanJob.Date >= date)
                            if (!RepeatJob.days[cleanJob.Day] || !weeks.Contains(cleanJob.Week))
                            {
                                toRemove.Add(cleanJob);
                            }
                    }

                    foreach (var c in toRemove)
                    {
                        if (c.Id != CleaningJobCopy.Id)
                            db.Remove(c);

                    }
                    db.SaveChanges();
                    if (RepeatJob.CleaningJobs == null || RepeatJob.CleaningJobs.Count <= 0)
                        return;

                    int day = getDay(date);

                    List<DateTime> weekDatetimes = new List<DateTime>();

                    for (int i = 0; i < 7; i++)
                    {
                        if (RepeatJob.days[i])
                        {
                            weekDatetimes.Add(date.AddDays(i - day));
                        }
                    }
                    int datesCount = weekDatetimes.Count;

                    for (int i = 0; i < iterations; i++)
                    {
                        for (int j = 0; j < datesCount; j++)
                        {

                            var cleanjob = RepeatJob.CleaningJobs.FirstOrDefault(x => x.Date.Date == weekDatetimes[j].Date);
                            if (cleanjob == null)
                            {
                                var defaultCleanJob = new CleaningJob();
                                defaultCleanJob.TeamId = CleaningJobCopy.TeamId;
                                defaultCleanJob.TimeEnd = CleaningJobCopy.TimeEnd;
                                defaultCleanJob.TimeStart = CleaningJobCopy.TimeStart;
                                defaultCleanJob.Location = CleaningJobCopy.Location;
                                defaultCleanJob.NoOfHours = CleaningJobCopy.NoOfHours;
                                defaultCleanJob.ClientId = CleaningJobCopy.ClientId;
                                defaultCleanJob.CleanerId = CleaningJobCopy.CleanerId;
                                defaultCleanJob.Amount = CleaningJobCopy.Amount;
                                defaultCleanJob.Date = weekDatetimes[j];
                                defaultCleanJob.RepeatJob = null;
                                defaultCleanJob.RepeatJobId = RepeatJobId;


                                db.Add(defaultCleanJob);
                                db.SaveChanges();
                            }
                            else
                            {


                                cleanjob.TeamId = CleaningJobCopy.TeamId;
                                cleanjob.TimeEnd = CleaningJobCopy.TimeEnd;
                                cleanjob.TimeStart = CleaningJobCopy.TimeStart;
                                cleanjob.Location = CleaningJobCopy.Location;
                                cleanjob.NoOfHours = CleaningJobCopy.NoOfHours;
                                cleanjob.ClientId = CleaningJobCopy.ClientId;
                                cleanjob.CleanerId = CleaningJobCopy.CleanerId;
                                cleanjob.Amount = CleaningJobCopy.Amount;
                                cleanjob.Date = weekDatetimes[j];

                                if (cleanjob.Id != CleaningJobCopy.Id)
                                {
                                    db.Update(cleanjob);
                                    db.SaveChanges();
                                }

                            }

                            weekDatetimes[j] = weekDatetimes[j].AddDays(7 * RepeatJob.RepeatFrequency);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }



    }
}
