using CalendarPract6.Model;
using CalendarPract6.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CalendarPract6.ViewModel.CardsVM
{
    internal class DayViewModel : BindingHelper
    {
        static MainViewModel mainViewModel;
        public Day DayExact { get; set; }
        public DayViewModel(Day day, MainViewModel mainViewModel)
        {
            this.DayExact  = day;
            DayViewModel.mainViewModel = mainViewModel;
            Date = day.Date.Day.ToString();

            string imagePath = "..\\..\\..\\Images\\Default.png";
            for (int i = 0; i < day.Crushes.Count; i++)
            {
                if (day.Crushes[i].IsSelected == true)
                {
                    imagePath = day.Crushes[i].IconPath;
                    break;
                }
            }
            FirstImage = imagePath;

            OpenCommand = new BindableCommand(_ => Open());
            CleanCommand = new BindableCommand(_ => Clean());


        }

        #region Переменные
        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        private string firstImage;
        public string FirstImage
        {
            get { return firstImage; }
            set
            {
                firstImage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Команды
        public BindableCommand OpenCommand { get; set; }
        public BindableCommand CleanCommand { get; set; }

        public void Open()
        {
            mainViewModel.ChangeToChoice(this.DayExact);
        }
        public void Clean()
        {

        }

        #endregion
    }
}
