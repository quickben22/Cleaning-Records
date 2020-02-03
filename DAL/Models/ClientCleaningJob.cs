using System;
using System.Collections.Generic;
using System.Text;

namespace CleaningRecords.DAL.Models
{
   public class ClientCleaningJob
    {

        public int Id { get; set; }
   
        public int CleaningJobId { get; set; }
        public int ClientId { get; set; }

        public virtual CleaningJob CleaningJob { get; set; }
        public virtual Client Client { get; set; }

    }
}
