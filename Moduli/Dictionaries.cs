using CleaningRecords.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRecords.Moduli
{
    public class ClientsList : Dictionary<int, string>
    {
        public ClientsList()
        {
            using (var db = new PodaciContext())
            {
                var Clients = db.Clients;
                foreach (var client in Clients)
                    this.Add(client.Id, client.Name + " " + client.Surname);
            }
        }
    }

    public class ClientsWithNullList : Dictionary<int, string>
    {
        public ClientsWithNullList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, "All Clients");
                var Clients = db.Clients;
                foreach (var client in Clients)
                    this.Add(client.Id, client.Name + " " + client.Surname);

            }

        }
    }



    public class ContractList : List<string>
    {
        public ContractList()
        {
            this.Add("Self employed");
            this.Add("Employee");
        }
    }

    public class YesNoList : List<string>
    {
        public YesNoList()
        {
            this.Add("");
            this.Add("NO");
            this.Add("YES");
        }
    }

    public class StatusList : Dictionary<int, string>
    {
        public StatusList()
        {
                this.Add(0, "Active");
                this.Add(1, "Inactive");
        }
    }

    public class JobStatusList : Dictionary<int, string>
    {
        public JobStatusList()
        {
    
            this.Add(0, "Active");
            this.Add(1, "Canceled");
            this.Add(2, "Completed");
            this.Add(3, "Payed");
        }
    }

    public class JobStatusWithNullList : Dictionary<int, string>
    {
        public JobStatusWithNullList()
        {
            this.Add(-1, "");
            this.Add(0, "Active");
            this.Add(1, "Canceled");
            this.Add(2, "Completed");
            this.Add(3, "Payed");
        }
    }


    public class CleanersList : Dictionary<int, string>
    {
        public CleanersList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, null);
                var Cleaners = db.Cleaners;
                if (Cleaners != null && Cleaners.Any())
                    foreach (var cleaner in Cleaners)
                        this.Add(cleaner.Id, cleaner.Name + " " + cleaner.Surname);

            }

        }
    }

    public class TeamsList : Dictionary<int, string>
    {
        public TeamsList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, null);
                var Teams = db.Teams;
                if (Teams != null && Teams.Any())
                    foreach (var team in Teams)
                        this.Add(team.Id, team.Name);

            }

        }
    }



    public class CleanersWithAllList : Dictionary<int, string>
    {
        public CleanersWithAllList()
        {
            using (var db = new PodaciContext())
            {
          
                this.Add(0, "All Cleaners");
                this.Add(-1, "No Cleaners");
                var Cleaners = db.Cleaners;
                if (Cleaners != null && Cleaners.Any())
                    foreach (var cleaner in Cleaners)
                        this.Add(cleaner.Id, cleaner.Name + " " + cleaner.Surname);

            }

        }
    }

    public class TeamsWithAllList : Dictionary<int, string>
    {
        public TeamsWithAllList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, "All Teams");
                this.Add(-1, "No Teams");
                var Teams = db.Teams;
                if (Teams != null && Teams.Any())
                    foreach (var team in Teams)
                        this.Add(team.Id, team.Name);

            }

        }
    }

    public class ServicesList : Dictionary<int, string>
    {
        public ServicesList()
        {
            using (var db = new PodaciContext())
            {
                this.Add(0, null);
                var Services = db.Services;
                if (Services != null && Services.Any())
                    foreach (var service in Services)
                        this.Add(service.Id, service.Name);

            }

        }
    }




}
