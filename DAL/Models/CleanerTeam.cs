﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleaningRecords.DAL.Models
{
    public class CleanerTeam
    {
        public int Id { get; set; }
        public int CleanerId { get; set; }
        public Cleaner Cleaner { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}
