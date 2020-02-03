using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleaningRecords.DAL
{
    public class PodaciContext :DbContext
    {
        public PodaciContext()
        {

        }


        public PodaciContext(DbContextOptions<PodaciContext> options)
               : base(options)
        {
        }





        public  DbSet<Client> Clients { get; set; }
     
        public  DbSet<CleaningJob> CleaningJobs { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}/CleaningDb1.db");

    }
}
