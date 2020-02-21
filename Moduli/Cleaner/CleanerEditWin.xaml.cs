using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for CleanerEditWin.xaml
    /// </summary>
    public partial class CleanerEditWin : Window
    {
        Cleaner Cleaner;
        public CleanerEditWin(int _cleanerId)
        {
            InitializeComponent();

            using (var db = new PodaciContext())
            {

                Cleaner = db.Cleaners
                    .FirstOrDefault(x => x.Id == _cleanerId);

                this.DataContext = Cleaner;
            }

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkAll.IsChecked == true)
            {
                Cleaner.Monday = true;
                Cleaner.Tuesday = true;
                Cleaner.Wednesday = true;
                Cleaner.Thursday = true;
                Cleaner.Friday = true;
                Cleaner.Saturday = true;
                Cleaner.Sunday = true;
            }
            else
            {
                Cleaner.Monday = false;
                Cleaner.Tuesday = false;
                Cleaner.Wednesday = false;
                Cleaner.Thursday = false;
                Cleaner.Friday = false;
                Cleaner.Saturday = false;
                Cleaner.Sunday = false;
            }
        }



        private void Start_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (e?.NewValue != null)
            {
                Cleaner.MondayStart = (DateTime)e.NewValue;
                Cleaner.TuesdayStart = (DateTime)e.NewValue;
                Cleaner.WednesdayStart = (DateTime)e.NewValue;
                Cleaner.ThursdayStart = (DateTime)e.NewValue;
                Cleaner.FridayStart = (DateTime)e.NewValue;
                Cleaner.SaturdayStart = (DateTime)e.NewValue;
                Cleaner.SundayStart = (DateTime)e.NewValue;
            }
        }

        private void End_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (e?.NewValue != null)
            {
                Cleaner.MondayEnd = (DateTime)e.NewValue;
                Cleaner.TuesdayEnd = (DateTime)e.NewValue;
                Cleaner.WednesdayEnd = (DateTime)e.NewValue;
                Cleaner.ThursdayEnd = (DateTime)e.NewValue;
                Cleaner.FridayEnd = (DateTime)e.NewValue;
                Cleaner.SaturdayEnd = (DateTime)e.NewValue;
                Cleaner.SundayEnd = (DateTime)e.NewValue;
            }
        }


    }
}
