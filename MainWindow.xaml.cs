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

            CalendarUserControl x2 = new CalendarUserControl();
            x2.Visibility = Visibility.Collapsed;
            DisplayGrid.Children.Add(x2);




        }

        private void hide()
        {
            int i = 0;

            List<int> toRemove = new List<int>();
            foreach (var child in DisplayGrid.Children)
            {
                if (child?.GetType().Name == "CalendarUserControl")
                    ((CalendarUserControl)child).Visibility = Visibility.Collapsed;
                else
                    toRemove.Add(i);
                i++;
            }

            foreach(var j in toRemove)
                DisplayGrid.Children.RemoveAt(j);
        }



        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            hide();
            ClientsUserControl x = new ClientsUserControl();
            DisplayGrid.Children.Add(x);


        }

        private void Cleaners_Click(object sender, RoutedEventArgs e)
        {
            hide();
            CleanerUserControl x1 = new CleanerUserControl();
            DisplayGrid.Children.Add(x1);


        }


        private void Clalendar_Click(object sender, RoutedEventArgs e)
        {
            hide();


            DisplayGrid.Children[0].Visibility = Visibility.Visible;

        }

        private void Teams_Click(object sender, RoutedEventArgs e)
        {
            hide();
            TeamsUserControl x3 = new TeamsUserControl();
            DisplayGrid.Children.Add(x3);

        }
    }
}
