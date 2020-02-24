﻿using CleaningRecords.DAL;
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
using System.ComponentModel;

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

                ClientObject = db.Clients
                    .FirstOrDefault(x => x.Id == ClientId);
                getCleaningJobs(db);
                ClientObject.setMonthsYears();
                ClientObject.setLocations();

                this.DataContext = ClientObject;
                dataGrid.ItemsSource = ClientObject.CleaningJobs;
            }

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

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {

            Fun.overWorked(ClientObject.CleaningJobs);

        }


        private void getCleaningJobs(PodaciContext db)
        {

            var cj = db.CleaningJobs
                .Include(x => x.Team)
                .ThenInclude(y => y.CleanerTeams)
                 .Where(x => x.ClientId == ClientObject.Id
                 && x.Date.Year == ClientObject.Year
                 && x.Date.Month == ClientObject.Month
                 && ((ClientObject.Cleaner != null && ClientObject.Cleaner != 0) ? ClientObject.Cleaner == x.CleanerId || x.Team.CleanerTeams.Any(y => y.CleanerId == ClientObject.Cleaner) : true)
                 && ((ClientObject.Status != null && ClientObject.Status != -1) ? ClientObject.Status == x.JobStatus : true)
                 && ((ClientObject.Service != null && ClientObject.Service != 0) ? ClientObject.Service == x.ServiceId : true));



            ClientObject.CleaningJobs = new ObservableCollection<CleaningJob>(cj);
            dataGrid.ItemsSource = ClientObject.CleaningJobs;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new PodaciContext())
                getCleaningJobs(db);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }




}
