using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

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

                        using (var db = new PodaciContext())
                        {
                            if (Object.GetType().Name == "TeamsHelper")
                            {
                                db.Remove(((TeamsHelper)Object).Team);
                                TeamsHelpers.Remove((TeamsHelper)Object);
                            }
                            else
                                db.Remove(Object);
                            db.SaveChanges();
                            if (Object.GetType().Name == "Client")
                                Clients.Remove((Client)Object);
                            if (Object.GetType().Name == "CleaningJob")
                                CleaningJobs.Remove((CleaningJob)Object);
                            if (Object.GetType().Name == "Cleaner")
                                Cleaners.Remove((Cleaner)Object);
                        }
                        break;
                    }
                case MessageBoxResult.Cancel:
                    {

                        break;
                    }
            }

        }
    }
}
