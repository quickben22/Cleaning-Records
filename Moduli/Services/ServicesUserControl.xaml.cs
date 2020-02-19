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
    /// Interaction logic for ServicesUserControl.xaml
    /// </summary>
    public partial class ServicesUserControl : UserControl
    {

        ServicesVM model = new ServicesVM();

        public ServicesUserControl()
        {
            InitializeComponent();

            using (var db = new PodaciContext())
            {
                model.Services = new ObservableCollection<Service>(db.Services);
                dataGrid.ItemsSource = model.Services;
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "Service")
            {
                Fun.Delete(((Button)sender).DataContext, Services: model.Services);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PodaciContext())
            {
                var service = db.Add(new Service ()).Entity;
                db.SaveChanges();
                model.Services.Add(service);
            }
        }
    }
}
