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
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var dir = Directory.GetCurrentDirectory();
            using (var db = new PodaciContext())
            {
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
                    db.Add(new Team { Name = "TestTeam"});
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
