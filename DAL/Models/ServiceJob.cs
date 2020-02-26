using System;
using System.Collections.Generic;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class ServiceJob
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int CleaningJobId { get; set; }
        public CleaningJob CleaningJob { get; set; }

    }
}
