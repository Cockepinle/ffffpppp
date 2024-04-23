using CalendarPract6.Model;
using CalendarPract6.View.Pages;
using CalendarPract6.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CalendarPract6.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        static ObservableCollection<Crush> allCrushes = new ObservableCollection<Crush>();
        static ObservableCollection<Day> SavedData = new ObservableCollection<Day>();
        public MainViewModel() 
        {
            currentPage = new CalendarPage();

            ReturnCommand = new BindableCommand(_ => Return());
            SaveCommand = new BindableCommand(_ => Save());
            CalendarPage page = new CalendarPage();

            Crush crush1 = new Crush("Билли Харгроув", "Billy.JPG", false);
            Crush crush2 = new Crush("Эдвард Каллен", "Edward.jpg", false);
            Crush crush3 = new Crush("Эдди Мансон", "Eddie.jpg", false);
            Crush crush4 = new Crush("Карлайл Каллен", "Carlisle.png", false);
            Crush crush5 = new Crush("Джим Хоппер", "Hopper.JPG", false);
            Crush crush6 = new Crush("Джаспер Хейл", "Jasper.jpg", false);
            Crush crush7 = new Crush("Генри Крил", "Henry.JPG", false);
            Crush crush8 = new Crush("Джейкоб Блэк", "Jacob.jpg", false);
            Crush crush9 = new Crush("Стив Харрингтон", "Steve.JPG", false);
            Crush crush10 = new Crush("Люцифер", "Lucifer.png", false);
            allCrushes.Add(crush1); allCrushes.Add(crush2); allCrushes.Add(crush3); allCrushes.Add(crush4); allCrushes.Add(crush5);
            allCrushes.Add(crush6); allCrushes.Add(crush7); allCrushes.Add(crush8); allCrushes.Add(crush9); allCrushes.Add(crush10);

            SavedData = SerDeser.Deserialize<ObservableCollection<Day>>("\\Model\\CalendarData.json");
            //здесь нужно получить дефолтную дату date (первый день месяца)
            page.SetCalendar(date, SavedData);

        }
        #region Переменные
        private string cardDate; //
        public string CardDate
        {
            get { return cardDate; }
            set 
            { 
                cardDate = value;
                OnPropertyChanged();
            }
        }

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Команды
        public BindableCommand SaveCommand { get; set; }
        public BindableCommand ReturnCommand { get; set; }

        private void Return()
        {
            currentPage = new CalendarPage();
        }

        private void Save()
        {

        }
        #endregion
    }
}
