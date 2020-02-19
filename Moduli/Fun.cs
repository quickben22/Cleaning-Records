using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
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
        public static void Delete(object Object, ObservableCollection<Client> Clients = null, ObservableCollection<CleaningJob> CleaningJobs = null, ObservableCollection<Cleaner> Cleaners = null, ObservableCollection<TeamsHelper> TeamsHelpers = null)
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
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

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
            foreach (var job in CleaningJobs)
            {
                if (job.CleanerId != null && job.CleanerId != 0)
                {
                    var HoursWeekly = Fun.GetCleanerHours((int)job.CleanerId, job.Date);

                    if (HoursWeekly >= 18)
                    {
                        using (var db = new PodaciContext())
                        {
                            var cleaner = db.Cleaners.FirstOrDefault(x => x.Id == (int)job.CleanerId);
                            MessageBox.Show($"Warning! {cleaner?.Name} {cleaner?.Surname} has {HoursWeekly} hours a week (on week {job.Week})!", "Possible cleaner over worked!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                    }
                }
            }

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
                MessageBox.Show("Error: " + ex?.Message);
            }

        }



    }
}
