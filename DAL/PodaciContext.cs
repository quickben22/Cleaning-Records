using CleaningRecords.DAL.Models;
using CleaningRecords.Global;
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

        public DbSet<Team> Teams { get; set; }

        public DbSet<RepeatJob> RepeatJobs { get; set; }

        public DbSet<Service> Services { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleanerTeam>()
                .HasKey(t => new { t.CleanerId, t.TeamId });

            modelBuilder.Entity<CleanerTeam>()
                .HasOne(pt => pt.Cleaner)
                .WithMany(p => p.CleanerTeams)
                .HasForeignKey(pt => pt.CleanerId);

            modelBuilder.Entity<CleanerTeam>()
                .HasOne(pt => pt.Team)
                .WithMany(t => t.CleanerTeams)
                .HasForeignKey(pt => pt.TeamId);

            modelBuilder.Entity<ServiceJob>()
             .HasKey(t => new { t.ServiceId, t.CleaningJobId });

            modelBuilder.Entity<ServiceJob>()
                .HasOne(pt => pt.Service)
                .WithMany(p => p.ServiceJobs)
                .HasForeignKey(pt => pt.ServiceId);

            modelBuilder.Entity<ServiceJob>()
                .HasOne(pt => pt.CleaningJob)
                .WithMany(t => t.ServiceJobs)
                .HasForeignKey(pt => pt.CleaningJobId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}/CleaningDb3.db");//{ZP.Dbdir}/{ZP.Db}"); //"{Directory.GetCurrentDirectory()}/CleaningDb3.db"

    }
}
