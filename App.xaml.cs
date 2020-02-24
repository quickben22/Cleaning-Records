using CleaningRecords.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using CleaningRecords.DAL.Models;
using AutoMapper;
using CleaningRecords.Global;

namespace CleaningRecords
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ZP.Dbdir = Directory.GetCurrentDirectory();
            ZP.OldDbdir=$"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\CleaningRecordsOldDb";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var dir = Directory.GetCurrentDirectory();
            using (var db = new PodaciContext())
            {
                try
                {
                    copyDB(db);
                }
                catch (Exception ex)
                {

                }

                if (!db.Clients.Any())
                {
                    db.Add(new Client { Name = "TestClient", CleaningJobs = new System.Collections.ObjectModel.ObservableCollection<CleaningJob> { new CleaningJob { Location = "Test Location" } } });
                    db.SaveChanges();
                }
                if (!db.Cleaners.Any())
                {
                    db.Add(new Cleaner { Name = "TestCleaner" });
                    db.SaveChanges();
                }

                if (!db.Teams.Any())
                {
                    db.Add(new Team { Name = "TestTeam" });
                    db.SaveChanges();
                }

                if (!db.Services.Any())
                {
                    db.Add(new Service { Name = "Parking Fee", Description = "Parking Fee", Rate = 1.8, Cost = 0 });
                    db.Add(new Service { Name = "CCS", Description = "Carpet Cleaning Service", Rate = 65, Cost = 0 });
                    db.Add(new Service { Name = "MSR2", Description = "Regular Team Sevice Reduced", Rate = 25, Cost = 0 });
                    db.Add(new Service { Name = "Cleaning Service Fee", Description = "Cleaning Service Fee", Rate = 0, Cost = 10 });
                    db.Add(new Service { Name = "DEEP", Description = "Deep Cleaning Service", Rate = 0, Cost = 0 });
                    db.Add(new Service { Name = "MSO", Description = "Team Service Once Off", Rate = 30, Cost = 0 });
                    db.Add(new Service { Name = "MSR", Description = "Regular Team Service", Rate = 30, Cost = 0 });
                    db.Add(new Service { Name = "DBS", Description = "Individual General Cleaning Service", Rate = 17.93, Cost = 0 });
                    db.SaveChanges();
                }

            }

            //    var builder = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //    Configuration = builder.Build();

            //    var serviceCollection = new ServiceCollection();
            //    ConfigureServices(serviceCollection);

            //    ServiceProvider = serviceCollection.BuildServiceProvider();

            //    var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            //    mainWindow.Show();
        }


        private void copyDB(PodaciContext db)
        {
            using (var db2 = new CleaningRecords.DAL.Models.OldModels.PodaciContext())
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DAL.Mappings.MappingProfile());
                });
                IMapper m = mappingConfig.CreateMapper();

                if (db2.Cleaners.Any() && !db.Cleaners.Any())
                {
                    var Cleaners = m.Map<List<CleaningRecords.DAL.Models.Cleaner>>(db2.Cleaners);
                    db.AddRange(Cleaners);
                }


                if (db2.Clients.Any() && !db.Clients.Any())
                {
                    var Clients = m.Map<List<CleaningRecords.DAL.Models.Client>>(db2.Clients);
                    db.AddRange(Clients);
                }


                if (db2.Teams.Any() && !db.Teams.Any())
                {

                    var Teams = m.Map<List<CleaningRecords.DAL.Models.Team>>(db2.Teams.Include(x => x.CleanerTeams));
                    db.AddRange(Teams);
                }
                if (db2.Services.Any() && !db.Services.Any())
                {

                    var Services = m.Map<List<CleaningRecords.DAL.Models.Service>>(db2.Services);
                    db.AddRange(Services);
                }



                if (db2.RepeatJobs.Any() && !db.RepeatJobs.Any())
                {
                    var RepeatJobs = m.Map<List<CleaningRecords.DAL.Models.RepeatJob>>(db2.RepeatJobs);
                    db.AddRange(RepeatJobs);
                }


                if (db2.CleaningJobs.Any() && !db.CleaningJobs.Any())
                {
                    var CleaningJobs = m.Map<List<CleaningRecords.DAL.Models.CleaningJob>>(db2.CleaningJobs);
                    db.AddRange(CleaningJobs);

                }

                db.SaveChanges();


            }
        }

        // private void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddDbContext<PodaciContext>
        //(options => options.UseSqlServer(
        //            Configuration.GetConnectionString("CleaningDatabase")));


        //     services.AddTransient(typeof(MainWindow));
        // }

        public void ConfigureServices(IServiceCollection services)
        {
      
            services.AddEntityFrameworkSqlite()
       .AddDbContext<PodaciContext>(
           options => { options.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}/data.db"); });

        }


    }
}
