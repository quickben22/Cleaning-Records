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

    
   

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}/CleaningDb2.db");

    }
}
