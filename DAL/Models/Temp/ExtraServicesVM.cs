using CleaningRecords.Moduli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace CleaningRecords.DAL.Models
{
    public class ExtraServicesVM : INotifyPropertyChanged
    {

        private int? _Service1Id;
        public int? Service1Id { get { return _Service1Id; } set { _Service1Id = (value); this.OnPropertyChanged("Service1Id"); } }

        private int? _Service2Id;
        public int? Service2Id { get { return _Service2Id; } set { _Service2Id = (value); this.OnPropertyChanged("Service2Id"); } }

        private int? _Service3Id;
        public int? Service3Id { get { return _Service3Id; } set { _Service3Id = (value); this.OnPropertyChanged("Service3Id"); } }

        private int? _Service4Id;
        public int? Service4Id { get { return _Service4Id; } set { _Service4Id = (value); this.OnPropertyChanged("Service4Id"); } }

        public CleaningJob CleaningJob { get; set; }

        public bool changed = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {


                try
                {
                    List<int?> list = new List<int?>();
                    if (Service1Id != null)
                        list.Add(Service1Id);
                    if (Service2Id != null)
                        list.Add(Service2Id);
                    if (Service3Id != null)
                        list.Add(Service3Id);
                    if (Service4Id != null)
                        list.Add(Service4Id);
                    if (list.Count != list.Distinct().Count())
                    {
                        MessageBox.Show("Error duplicate Services!");
                        // Duplicates exist
                    }
                    else
                        using (var db = new PodaciContext())
                        {

                            //foreach (var sj in CleaningJob.ServiceJobs)
                            //    db.Remove(sj);
                            //db.SaveChanges();

                          
                            List<ServiceJob> toAdd = new List<ServiceJob>();
                            if (Service1Id != null && Service1Id != 0)
                                toAdd.Add(new ServiceJob { ServiceId = (int)Service1Id, CleaningJobId = CleaningJob.Id });
                            if (Service2Id != null && Service2Id != 0)
                                toAdd.Add(new ServiceJob { ServiceId = (int)Service2Id, CleaningJobId = CleaningJob.Id });
                            if (Service3Id != null && Service3Id != 0)
                                toAdd.Add(new ServiceJob { ServiceId = (int)Service3Id, CleaningJobId = CleaningJob.Id });
                            if (Service4Id != null && Service4Id != 0)
                                toAdd.Add(new ServiceJob { ServiceId = (int)Service4Id, CleaningJobId = CleaningJob.Id });

                            Fun.checkAndSaveServiceJobs(toAdd, CleaningJob.ServiceJobs, db);

                          
                            CleaningJob.ServiceJobs = toAdd;
                        }

                    changed = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ExtraServices Update error: " + ex.Message);
                }


                PropertyChanged(this, new PropertyChangedEventArgs(prop));



            }
        }

    }
}
