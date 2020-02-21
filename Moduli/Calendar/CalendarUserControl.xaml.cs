using CleaningRecords.DAL;
using CleaningRecords.DAL.Models;
using CleaningRecords.PDF;
using Microsoft.EntityFrameworkCore;
using MonthCalendar;
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

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for CalendarUserControl.xaml
    /// </summary>
    public partial class CalendarUserControl : UserControl
    {

        private List<CalendarViewModel> models = new List<CalendarViewModel>();

        List<MonthCalendarControl> calendars = new List<MonthCalendarControl>();

        public CalendarUserControl()
        {
            InitializeComponent();
            Loaded += Window1_Loaded;


        }



        private void Window1_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Random rand = new Random(System.DateTime.Now.Second);

            //for (int i = 1; i <= 5; i++)
            //{
            //    Appointment apt = new Appointment();
            //    apt.CleaningJobID = i;
            //    apt.Date = new System.DateTime(System.DateTime.Now.Year, 2, 8);
            //    apt.Subject = "9:00 - 12:00 \n Marko Mesiček";
            //    _myAppointmentsList.Add(apt);
            //}

            models.Add(new CalendarViewModel { CleanerId = 0, TeamId = 0, ClientId = 0 });
            this.MainTab.DataContext = models[0];
            calendars.Add(AptCalendar);

            SetAppointments(0);
        }
        private void DayBoxDoubleClicked_event(NewAppointmentEventArgs e)
        {
            CalendarEditWin dlg = new CalendarEditWin(date: Convert.ToDateTime(e.StartDate));

            dlg.ShowDialog();
            SetAppointments(TabsMain.SelectedIndex);
            //MessageBox.Show("You double-clicked on day " + Convert.ToDateTime(e.StartDate).ToShortDateString(), "Calendar Event", MessageBoxButton.OK);
        }

        private void AppointmentDblClicked(int CleaningJobID)
        {
            CalendarEditWin dlg = new CalendarEditWin(CleaningJobId: CleaningJobID);
            dlg.ShowDialog();
            SetAppointments(TabsMain.SelectedIndex);
            //MessageBox.Show("You double-clicked on appointment with ID = " + CleaningJobID, "Calendar Event", MessageBoxButton.OK);
        }

        private void DisplayMonthChanged(MonthChangedEventArgs e)
        {
            SetAppointments(TabsMain.SelectedIndex);
        }


        private void setWorkHours(PodaciContext db, int index)
        {
            if (models[index].CleanerId != null && models[index].CleanerId != 0)
            {
                var cleaner = db.Cleaners.FirstOrDefault(x => x.Id == models[index].CleanerId);
                if (cleaner.Monday)
                    models[index].Monday = $"{cleaner.MondayStart.ToString("HH:mm")} - {cleaner.MondayEnd.ToString("HH:mm")}";
                else
                    models[index].Monday = "Not available";
              
                if (cleaner.Tuesday)
                    models[index].Tuesday = $"{cleaner.TuesdayStart.ToString("HH:mm")} - {cleaner.TuesdayEnd.ToString("HH:mm")}";
                else
                    models[index].Tuesday = "Not available";

                if (cleaner.Wednesday)
                    models[index].Wednesday = $"{cleaner.WednesdayStart.ToString("HH:mm")} - {cleaner.WednesdayEnd.ToString("HH:mm")}";
                else
                    models[index].Wednesday = "Not available";

                if (cleaner.Thursday)
                    models[index].Thursday = $"{cleaner.ThursdayStart.ToString("HH:mm")} - {cleaner.ThursdayEnd.ToString("HH:mm")}";
                else
                    models[index].Thursday = "Not available";

                if (cleaner.Friday)
                    models[index].Friday = $"{cleaner.FridayStart.ToString("HH:mm")} - {cleaner.FridayEnd.ToString("HH:mm")}";
                else
                    models[index].Friday = "Not available";

                if (cleaner.Saturday)
                    models[index].Saturday = $"{cleaner.SaturdayStart.ToString("HH:mm")} - {cleaner.SaturdayEnd.ToString("HH:mm")}";
                else
                    models[index].Saturday = "Not available";

                if (cleaner.Sunday)
                    models[index].Sunday = $"{cleaner.SundayStart.ToString("HH:mm")} - {cleaner.SundayEnd.ToString("HH:mm")}";
                else
                    models[index].Sunday = "Not available";

                if (cleaner.NotAvailable)
                    models[index].NotAvailable = $"{cleaner.NotAvailableStart.ToString("dd.MM.yyyy.")} - {cleaner.NotAvailableEnd.ToString("dd.MM.yyyy.")}";
                else
                    models[index].NotAvailable = "No breaks";
            }
            else
            {
                models[index].Monday = "00:00 - 00:00";
                models[index].Tuesday = "00:00 - 00:00";
                models[index].Wednesday = "00:00 - 00:00";
                models[index].Thursday = "00:00 - 00:00";
                models[index].Friday = "00:00 - 00:00";
                models[index].Saturday = "00:00 - 00:00";
                models[index].Sunday = "00:00 - 00:00";
                models[index].NotAvailable = "No breaks";
            }
        }

        private void SetAppointments(int index)
        {
            if (index < 0) return;

            List<Appointment> _myAppointmentsList = new List<Appointment>();
            using (var db = new PodaciContext())
            {
                setWorkHours(db, index);


                var jobs = db.CleaningJobs
                    .Include(x => x.Client)
                    .Include(x => x.Team)
                    .ThenInclude(x => x.CleanerTeams)
                    .ThenInclude(y => y.Cleaner)
                    .Include(x => x.Cleaner)
                      .Include(x => x.Service)
                    .Where(x => x.Date.Month == calendars[index].DisplayStartDate.Month).ToList();

                if (models[index].TeamId != null && models[index].TeamId != 0)
                    jobs = jobs.Where(x => x.TeamId == models[index].TeamId)?.ToList();
                if (models[index].CleanerId == -1)
                {
                    jobs = jobs.Where(x => x.CleanerId == null && x.TeamId == null)?.ToList();
                }
                else if (models[index].CleanerId != null && models[index].CleanerId != 0)
                    jobs = jobs.Where(x => x.CleanerId == models[index].CleanerId || x.Team?.CleanerTeams?.FirstOrDefault(y => y.CleanerId == models[index].CleanerId) != null)?.ToList();

                if (models[index].ClientId != null && models[index].ClientId != 0)
                    jobs = jobs.Where(x => x.ClientId == models[index].ClientId)?.ToList();

                foreach (var job in jobs)
                {
                    Appointment apt = new Appointment();
                    apt.CleaningJobID = job.Id;
                    apt.Date = job.Date;
                    string cleaner = "";
                    string service = "";
                    if (job.Cleaner != null)
                    {
                        apt.CleanerID = (int)job.CleanerId;
                        apt.Color = job?.Cleaner?.Color;
                        cleaner = job?.Cleaner?.Name + " " + job?.Cleaner?.Surname;

                    }
                    if (job.TeamId != null && job.TeamId != 0)
                    {
                        if (models[index].CleanerId != null && models[index].CleanerId != 0)
                        {
                            var c = job.Team?.CleanerTeams?.FirstOrDefault(x => x.CleanerId == models[index].CleanerId)?.Cleaner;
                            cleaner = c?.Name + " " + c?.Surname;
                            apt.CleanerID = c?.Id;
                            apt.Color = c?.Color;
                        }
                        else
                        {
                            cleaner = job?.Team?.Name;
                            apt.TeamID = (int)job.TeamId;
                            apt.Color = job?.Team?.Color;
                        }
                    }
                    if (job.Service != null && job.ServiceId != 0)
                    {
                        apt.ServiceId = (int)job.ServiceId;
                        apt.ServiceColor = job?.Service?.Color;
                        service = job?.Service?.Name;

                    }
                    apt.Subject = $"{job.TimeStart.ToString("H:mm")} - {job.TimeEnd.ToString("H:mm")} - {job.Client.Name} {job.Client.Surname}\n {cleaner } - {service }  ";
                    _myAppointmentsList.Add(apt);
                }

                CalculateWeekHours(index, db);
            }

            calendars[index].MonthAppointments = _myAppointmentsList.FindAll(new System.Predicate<Appointment>((Appointment apt) => apt.Date != null && Convert.ToDateTime(apt.Date).Month == calendars[index].DisplayStartDate.Month && Convert.ToDateTime(apt.Date).Year == calendars[index].DisplayStartDate.Year));
        }

        private void CalculateWeekHours(int index, PodaciContext db)
        {

            var month = calendars[index].DisplayStartDate.Month;
            var year = calendars[index].DisplayStartDate.Year;
            var week = Fun.getWeek(new DateTime(year, month, 1));

            for (int i = 0; i < 5; i++)
            {
                var sum = db.CleaningJobs.Where(x => x.Week == week)?.Select(x => x.NoOfHours)?.Sum() ?? 0;
                if (i == 0)
                    models[index].Week1 = sum;
                if (i == 1)
                    models[index].Week2 = sum;
                if (i == 2)
                    models[index].Week3 = sum;
                if (i == 3)
                    models[index].Week4 = sum;
                if (i == 4)
                    models[index].Week5 = sum;
                week++;
            }

        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e?.AddedItems != null && e.AddedItems.Count > 0)
            {



                SetAppointments(TabsMain.SelectedIndex);
            }
        }


        private void NewTab_Click(object sender, RoutedEventArgs e)
        {
            var count = TabsMain.Items.Count;
            TabItem newTabItem = new TabItem
            {
                Header = "Tab" + count,

            };

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });


            grid.Children.Add(new TextBlock { HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(20, 10, 0, 0), Text = "Cleaner:", TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top });

            ComboBox combo = new ComboBox { ItemsSource = new CleanersWithAllList(), SelectedValuePath = "Key", DisplayMemberPath = "Value", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Width = 160, Margin = new Thickness(70, 5, 0, 0) };
            Binding b = new Binding("CleanerId");
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            combo.SetBinding(ComboBox.SelectedValueProperty, b);
            combo.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
            grid.Children.Add(combo);

            grid.Children.Add(new TextBlock { HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(270, 10, 0, 0), Text = "Team:", TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top });
            combo = new ComboBox { ItemsSource = new TeamsWithAllList(), SelectedValuePath = "Key", DisplayMemberPath = "Value", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Width = 160, Margin = new Thickness(310, 5, 0, 0) };
            b = new Binding("TeamId");
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            combo.SetBinding(ComboBox.SelectedValueProperty, b);
            combo.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
            grid.Children.Add(combo);

            grid.Children.Add(new TextBlock { HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(490, 10, 0, 0), Text = "Client:", TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Top });
            combo = new ComboBox { ItemsSource = new ClientsWithNullList(), SelectedValuePath = "Key", DisplayMemberPath = "Value", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Width = 160, Margin = new Thickness(530, 5, 0, 0) };
            b = new Binding("ClientId");
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            combo.SetBinding(ComboBox.SelectedValueProperty, b);
            combo.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);
            grid.Children.Add(combo);

            var month = new MonthCalendarControl { VerticalAlignment = VerticalAlignment.Stretch, VerticalContentAlignment = VerticalAlignment.Stretch };
            month.SetValue(Grid.RowProperty, 1);
            month.DisplayMonthChanged += new MonthCalendarControl.DisplayMonthChangedEventHandler(DisplayMonthChanged);
            month.DayBoxDoubleClicked += new MonthCalendarControl.DayBoxDoubleClickedEventHandler(DayBoxDoubleClicked_event);
            month.AppointmentDblClicked += new MonthCalendarControl.AppointmentDblClickedEventHandler(AppointmentDblClicked);
            month.SizeChanged += new SizeChangedEventHandler(AptCalendar_SizeChanged);

            grid.Children.Add(month);

            Grid gridRight = new Grid();
            gridRight.SetValue(Grid.RowProperty, 1);
            gridRight.SetValue(Grid.ColumnProperty, 1);

            grid.Children.Add(gridRight);

            newTabItem.Content = grid;

            models.Add(new CalendarViewModel { CleanerId = 0, TeamId = 0, ClientId = 0 });
            newTabItem.DataContext = models[count];
            calendars.Add(month);



            TabsMain.Items.Add(newTabItem);

            SetAppointments(count);

        }

        private void CloseTab_Click(object sender, RoutedEventArgs e)
        {








            if (TabsMain.SelectedIndex > 0)
            {

                var messageBoxText = "Remove this tab?";

                string caption = "Confirm Removal";
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // Process message box results
                switch (result)
                {
                    case MessageBoxResult.OK:
                        {

                            models.RemoveAt(TabsMain.SelectedIndex);
                            calendars.RemoveAt(TabsMain.SelectedIndex);
                            TabsMain.Items.RemoveAt(TabsMain.SelectedIndex);
                            break;
                        }
                    case MessageBoxResult.Cancel:
                        {

                            break;
                        }
                }


            }

        }




        private void RenameTab_Click(object sender, RoutedEventArgs e)
        {

            if (TabsMain.SelectedIndex > -1)
            {
                InputDialogSimple inputDialog = new InputDialogSimple("Tab name:", "");
                if (inputDialog.ShowDialog() == true)
                {
                    if (!string.IsNullOrWhiteSpace(inputDialog.Answer))
                        ((TabItem)TabsMain.Items[TabsMain.SelectedIndex]).Header = inputDialog.Answer;
                }
            }




        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
                refresh();
        }

        private void refresh()
        {

            foreach (TabItem ti in TabsMain.Items)
            {
                Grid grid = (Grid)ti.Content;
                foreach (var c in grid.Children)
                {
                    if (c?.GetType().Name == "ComboBox")
                    {
                        Fun.RefreshCombo(c);

                    }
                }
            }
            SetAppointments(TabsMain.SelectedIndex);


        }

        private void TabsMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAppointments(TabsMain.SelectedIndex);
        }


        private void AptCalendar_SizeChanged(object sender, SizeChangedEventArgs e)
        {




            var height = calendars[TabsMain.SelectedIndex].ActualHeight;
            if (height > 0)
            {


                var koef = 5.25;
                var margin = height - 5.5 * height / koef;
                foreach (TabItem ti in TabsMain.Items)
                {
                    Grid grid = (Grid)ti.Content;
                    foreach (var g in grid.Children)
                    {
                        if (g?.GetType().Name == "Grid")
                        {
                            ((Grid)g).Children.Clear();

                            var tb1 = new TextBlock { FontWeight = FontWeights.Bold, FontSize = 18, Margin = new Thickness(10, margin + height / koef, 0, 0) };
                            Binding b = new Binding("Week1");
                            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                            tb1.SetBinding(TextBlock.TextProperty, b);
                            ((Grid)g).Children.Add(tb1);
                            tb1 = new TextBlock { FontWeight = FontWeights.Bold, FontSize = 18, Margin = new Thickness(10, margin + height / koef * 2, 0, 0) };
                            b = new Binding("Week2");
                            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                            tb1.SetBinding(TextBlock.TextProperty, b);
                            ((Grid)g).Children.Add(tb1);
                            tb1 = new TextBlock { FontWeight = FontWeights.Bold, FontSize = 18, Margin = new Thickness(10, margin + height / koef * 3, 0, 0) };
                            b = new Binding("Week3");
                            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                            tb1.SetBinding(TextBlock.TextProperty, b);
                            ((Grid)g).Children.Add(tb1);
                            tb1 = new TextBlock { FontWeight = FontWeights.Bold, FontSize = 18, Margin = new Thickness(10, margin + height / koef * 4, 0, 0) };
                            b = new Binding("Week4");
                            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                            tb1.SetBinding(TextBlock.TextProperty, b);
                            ((Grid)g).Children.Add(tb1);
                            tb1 = new TextBlock { FontWeight = FontWeights.Bold, FontSize = 18, Margin = new Thickness(10, margin + height / koef * 5, 0, 0) };
                            b = new Binding("Week5");
                            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                            tb1.SetBinding(TextBlock.TextProperty, b);
                            ((Grid)g).Children.Add(tb1);

                        }
                    }
                }
            }



        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var month = calendars[TabsMain.SelectedIndex].DisplayStartDate.Month;
            var year = calendars[TabsMain.SelectedIndex].DisplayStartDate.Year;
            var pdf = new GeneratePDF();
            using (var db = new PodaciContext())
                pdf.Create(month, year, models[TabsMain.SelectedIndex].CleanerId, db);
        }
    }
}
