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
                var cleaner = db.Add(new Cleaner {Monday=true,Tuesday=true,Wednesday=true,Thursday=true,Friday=true,Saturday=true,Sunday=true,
                    NotAvailableStart=DateTime.Now,NotAvailableEnd=DateTime.Now, NotAvailableStart2 = DateTime.Now, NotAvailableEnd2 = DateTime.Now,
                    HolidayStart = DateTime.Now,
                    HolidayEnd = DateTime.Now,
                    HolidayStart2 = DateTime.Now,
                    HolidayEnd2 = DateTime.Now
                }).Entity;
                db.SaveChanges();
                Cleaners.Cleaners.Add(cleaner);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "Cleaner")
            {
                Fun.Delete(((Button)sender).DataContext, Cleaners: Cleaners.Cleaners);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "Cleaner")
            {

                CleanerEditWin dlg = new CleanerEditWin(((Cleaner)((Button)sender).DataContext).Id);
                dlg.ShowDialog();
            }
        }
    }

    

}
