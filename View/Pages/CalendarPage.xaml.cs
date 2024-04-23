using CalendarPract6.Model;
using CalendarPract6.View.Cards;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace CalendarPract6.View.Pages
{
    /// <summary>
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        static MainViewModel mainViewModel;
        public CalendarPage(MainViewModel mainViewModel)
        {
            CalendarPage.mainViewModel = mainViewModel;
            InitializeComponent();
            DataContext = mainViewModel;
        }

        public void SetCalendar(DateTime dateDefault, ObservableCollection<Day> data)
        {
            DayWrap.Children.Clear();
            ObservableCollection<Crush> crushes = new ObservableCollection<Crush>();
            int dayNum = DateTime.DaysInMonth(dateDefault.Year, dateDefault.Month);

            for (int i = 1; i <= dayNum; i++)
            {
                DateTime date = new DateTime(dateDefault.Year, dateDefault.Month, i);
                crushes = data[0].Crushes;
                for (int j = 0; j < data.Count(); j++)
                {
                    if (data[j].Date == date)
                    {
                        crushes = data[j].Crushes;
                    }
                }
                foreach (var dayData in data)
                {
                    if (dayData.Date == date)
                    {
                        crushes = dayData.Crushes;
                        break;
                    }
                }

                Day newday = new Day(date, crushes);
                DayView day = new DayView(newday, mainViewModel);
                DayWrap.Children.Add(day);
            }

            string monthYear = new DateTime(dateDefault.Year, dateDefault.Month, 1).ToString("MMMM, yyyy");
            mainViewModel.DateLabel = monthYear;
        }
    }
}