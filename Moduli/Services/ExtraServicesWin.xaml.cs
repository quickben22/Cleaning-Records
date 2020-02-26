using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ExtraServicesWin.xaml
    /// </summary>
    public partial class ExtraServicesWin : Window
    {

        ExtraServicesVM model = new ExtraServicesVM();

        public ExtraServicesWin(int CleaningJobId)
        {
            InitializeComponent();

            using (var db = new PodaciContext())
            {
                var cj = db.CleaningJobs.Include(x => x.ServiceJobs).FirstOrDefault(x => x.Id == CleaningJobId);
                if (cj != null)
                    model.CleaningJob = cj;
                var serviceJobs = cj.ServiceJobs?.ToList();
                if (serviceJobs != null && serviceJobs.Count > 0)
                    model.Service1Id = serviceJobs[0].ServiceId;
                if (serviceJobs != null && serviceJobs.Count > 1)
                    model.Service2Id = serviceJobs[1].ServiceId;
                if (serviceJobs != null && serviceJobs.Count > 2)
                    model.Service3Id = serviceJobs[2].ServiceId;
                if (serviceJobs != null && serviceJobs.Count > 3)
                    model.Service4Id = serviceJobs[3].ServiceId;
            }
            this.DataContext = model;
        }



        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
