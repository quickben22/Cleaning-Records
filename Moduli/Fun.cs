using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


    }
}
