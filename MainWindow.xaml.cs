using CleaningRecords.Moduli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CleaningRecords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

       

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            ClientsUserControl x = new ClientsUserControl();
            DisplayGrid.Children.Add(x);
        }

        private void Cleaners_Click(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            CleanerUserControl x = new CleanerUserControl();
            DisplayGrid.Children.Add(x);
        }


        private void Clalendar_Click(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            CalendarUserControl x = new CalendarUserControl();
            DisplayGrid.Children.Add(x);
        }

        private void Teams_Click(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            TeamsUserControl x = new TeamsUserControl();
            DisplayGrid.Children.Add(x);
        }
    }
}
