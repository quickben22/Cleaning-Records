using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for ClientsUserControl.xaml
    /// </summary>
    public partial class ClientsUserControl : UserControl
    {
        ClientsViewModel Clients = new ClientsViewModel();
        public ClientsUserControl()
        {
            InitializeComponent();


            using (var db = new PodaciContext())
            {
                Clients.Clients = new ObservableCollection<Client>(db.Clients);
                dataGrid.ItemsSource = Clients.Clients;
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "Client")
            {

                ClientEditWin dlg = new ClientEditWin(((Client)((Button)sender).DataContext).Id);
                dlg.ShowDialog();
            }
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PodaciContext())
            {
                var client = db.Add(new Client()).Entity;
                db.SaveChanges();
                Clients.Clients.Add(client);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext.GetType().Name == "Client")
            {
                using (var db = new PodaciContext())
                {
                    db.Remove(((Client)((Button)sender).DataContext));
                    db.SaveChanges();
                    Clients.Clients.Remove(((Client)((Button)sender).DataContext));
                }
            }
        }
    }
}
