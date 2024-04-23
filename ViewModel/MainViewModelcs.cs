using CalendarPract6.Model;
using CalendarPract6.View.Cards;
using CalendarPract6.View.Pages;
using CalendarPract6.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CalendarPract6
{
    public class MainViewModel : BindingHelper
    {
        static ObservableCollection<Crush> allCrushes = new ObservableCollection<Crush>();
        static ObservableCollection<Day> SavedData = new ObservableCollection<Day>();
        static Day day;
        public MainViewModel()
        {
            CurrentPage = new CalendarPage(this);

            BackCommand = new BindableCommand(_ => Back());
            ForwardCommand = new BindableCommand(_ => Forward());
            ReturnCommand = new BindableCommand(_ => Return());
            SaveCommand = new BindableCommand(_ => Save());


            Crush crush1 = new Crush("Билли Харгроув", "..\\..\\..\\Images\\Billy.JPG", false);
            Crush crush2 = new Crush("Эдвард Каллен", "..\\..\\..\\Images\\Edward.jpg", false);
            Crush crush3 = new Crush("Эдди Мансон", "..\\..\\..\\Images\\Eddie.jpg", false);
            Crush crush4 = new Crush("Карлайл Каллен", "..\\..\\..\\Images\\Carlisle.png", false);
            Crush crush5 = new Crush("Джим Хоппер", "..\\..\\..\\Images\\Hopper.JPG", false);
            Crush crush6 = new Crush("Джаспер Хейл", "..\\..\\..\\Images\\Jasper.jpg", false);
            Crush crush7 = new Crush("Генри Крил", "..\\..\\..\\Images\\Henry.JPG", false);
            Crush crush8 = new Crush("Джейкоб Блэк", "..\\..\\..\\Images\\Jacob.jpg", false);
            Crush crush9 = new Crush("Стив Харрингтон", "..\\..\\..\\Images\\Steve.JPG", false);
            Crush crush10 = new Crush("Люцифер", "..\\..\\..\\Image\\Lucifer.png", false);
            allCrushes.Add(crush1); allCrushes.Add(crush2); allCrushes.Add(crush3); allCrushes.Add(crush4); allCrushes.Add(crush5);
            allCrushes.Add(crush6); allCrushes.Add(crush7); allCrushes.Add(crush8); allCrushes.Add(crush9); allCrushes.Add(crush10);

            SavedData = SerDeser.Deserialize<ObservableCollection<Day>>("\\Model\\CalendarData.json");
            //здесь нужно получить дефолтную дату date (первый день месяца)
            CurrentPage.SetCalendar(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), SavedData);

        }
        public void ChangeToChoice(Day day)
        {
            AllCrushesView.Clear();
            MainViewModel.day = day;
            CurrentPage = new ChoicePage(this);
            allCrushes = day.Crushes;
            foreach (Crush crush in allCrushes)
            {
                CrushView newCrush = new CrushView();
                newCrush.Image = crush.IconPath;
                newCrush.CrushName = crush.CrushName;
                newCrush.IsChecked = crush.IsSelected;
                AllCrushesView.Add(newCrush);
            }
            CardDate = day.Date.ToShortDateString();

        }
        #region Переменные
        private string cardDate;
        public string CardDate
        {
            get { return cardDate; }
            set
            {
                cardDate = value;
                OnPropertyChanged();
            }
        }

        private dynamic currentPage;
        public dynamic CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CrushView> allCrushesView = new ObservableCollection<CrushView>();
        public ObservableCollection<CrushView> AllCrushesView
        {
            get { return allCrushesView; }
            set
            {
                allCrushesView = value;
                OnPropertyChanged();
            }
        }

        private string dateLabel;
        public string DateLabel
        {
            get { return dateLabel; }
            set
            {
                dateLabel = value;
                OnPropertyChanged(nameof(DateLabel));
            }
        }

        #endregion

        #region Команды
        public BindableCommand SaveCommand { get; set; }
        public BindableCommand ReturnCommand { get; set; }
        public BindableCommand BackCommand { get; set; }
        public BindableCommand ForwardCommand { get; set; }
        private void Return()
        {
            CurrentPage = new CalendarPage(this);
            CurrentPage.SetCalendar(currentMonth, SavedData);
        }
        
        private void Save()
        {
           
            ObservableCollection<Crush> crushes = new ObservableCollection<Crush>();
            foreach (var item in AllCrushesView)
            {
                string fileName = item.Image;
                Crush crush = new Crush(item.CrushName, fileName, item.IsChecked);
                
                crushes.Add(crush);
            }
            
            bool ifExict = false;
            for (int i = 0; i < SavedData.Count; i++)
            {
                if (SavedData[i].Date == day.Date)
                {
                    SavedData[i].Crushes = crushes;
                    ifExict = true;
                    break;
                }
            }
            if (!ifExict)
            {
                Day newday = new Day(day.Date, crushes);
                SavedData.Add(newday);
            }
            SerDeser.Serialize<ObservableCollection<Day>>(SavedData, "\\Model\\CalendarData.json");
            Return();

            DateTime currentMonthDate = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            CurrentPage.SetCalendar(currentMonthDate, SavedData);
        }
        private DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private void Back()
        {
            currentMonth = currentMonth.AddMonths(-1);
            DateTime firstDayOfPreviousMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            CurrentPage.SetCalendar(firstDayOfPreviousMonth, SavedData);
        }

        private void Forward()
        {
            currentMonth = currentMonth.AddMonths(1);
            DateTime firstDayOfNextMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            CurrentPage.SetCalendar(firstDayOfNextMonth, SavedData);
        }
        #endregion
    }
}