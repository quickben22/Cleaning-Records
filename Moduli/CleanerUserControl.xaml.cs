using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CleanerUserControl.xaml
    /// </summary>
    public partial class CleanerUserControl : UserControl
    {
        CleanersViewModel Cleaners = new CleanersViewModel();
        public CleanerUserControl()
        {
            InitializeComponent();

            using (var db = new PodaciContext())
            {
                Cleaners.Cleaners = new ObservableCollection<Cleaner>(db.Cleaners);
                dataGrid.ItemsSource = Cleaners.Cleaners;

            }
        }

            private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PodaciContext())
            {
                var cleaner = db.Add(new Cleaner()).Entity;
                db.SaveChanges();
                Cleaners.Cleaners.Add(cleaner);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "Cleaner")
            {
                using (var db = new PodaciContext())
                {
                    db.Remove(((Cleaner)((Button)sender).DataContext));
                    db.SaveChanges();
                    Cleaners.Cleaners.Remove(((Cleaner)((Button)sender).DataContext));
                }
            }
        }
    }
}
