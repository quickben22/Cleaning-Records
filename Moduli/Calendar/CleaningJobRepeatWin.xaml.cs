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
using CleaningRecords.DAL.Models;
using CleaningRecords.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CleaningRecords.Global;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for CleaningJobRepeatWin.xaml
    /// </summary>
    public partial class CleaningJobRepeatWin : Window
    {

        CleaningJob cleaningJob;
        public RepeatJob model;
        //int startDay = -1;
        public CleaningJobRepeatWin(int cleaningJobId)
        {
            InitializeComponent();
            //CleaningJobId = cleaningJobId;



            using (var db = new PodaciContext())
            {
                cleaningJob = db.CleaningJobs.Include(x => x.RepeatJob).FirstOrDefault(x => x.Id == cleaningJobId);
                if (cleaningJob.RepeatJob != null)
                {
                    model = cleaningJob.RepeatJob;
                }
                else
                {
                    model = new RepeatJob();
                }
                model.AllDaysToDays();
                if (model.AllDays == 0)
                {
                    var day = Fun.getDay(cleaningJob.Date);
                    model.days[day] = true;
                }

                //var day = Fun.getDay(cleanJob.Date);
                //var week = Fun.getWeek(cleanJob.Date);
                //startDay = day;
                //model.days[day] = true;

                //var cleanJobs = db.CleaningJobs.Include(x => x.RepeatJob).Where(x => x.Id != cleaningJobId && x.ClientId == cleanJob.ClientId && x.RepeatJobId == model.Id && x.Week == week)?.ToList();
                //if (cleanJobs != null)
                //    foreach (var c in cleanJobs)
                //    {
                //        var d = (((int)c.Date.DayOfWeek == 0) ? 7 : (int)c.Date.DayOfWeek) - 1; ;
                //        model.days[d] = true;
                //    }
            }

            RepeatCombo.ItemsSource = ZP.RepeatDict;
            this.DataContext = model;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (model.RepeatFrequency != 0 && !model.days.Contains(true))
            {
                MessageBox.Show("Repeating day has to be selected!");
                return;
            }

            using (var db = new PodaciContext())
            {

                if (model.RepeatFrequency == 0)
                {
                    if (model.Id != 0)
                    {
                        model.AllDays = 0;
                        db.Update(model);
                        db.SaveChanges();
                    }

                }
                else
                {
                    model.daysToAllDays();
                    if (cleaningJob.RepeatJobId == null)
                    {
                        var RepeatJob = db.Add(model);
                        db.SaveChanges();
                        cleaningJob.RepeatJobId = RepeatJob?.Entity?.Id;
                        db.Update(cleaningJob);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Update(model);
                        db.SaveChanges();
                    }
                }


                //if (model.days[startDay] == false && cleanJob.Repeating != 0)
                //{
                //    var jobs = db.CleaningJobs.Where(x => x.Id != cleanJob.Id && x.ClientId == cleanJob.ClientId && x.Date >= cleanJob.Date && x.Repeating == cleanJob.Repeating);
                //    foreach (var job in jobs)
                //        db.CleaningJobs.Remove(job);
                //}
            }

            Fun.setRepeatingJobs(cleaningJob.RepeatJobId ?? model.Id, cleaningJob);
            Ok = true;
            Close();
        }


        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public bool Ok = false;


    }
}
