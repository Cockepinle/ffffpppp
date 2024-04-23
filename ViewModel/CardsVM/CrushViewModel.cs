using CalendarPract6.Model;
using CalendarPract6.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CalendarPract6.ViewModel.CardsVM
{

    internal class CrushViewModel : BindingHelper
    {
        public CrushViewModel(Crush crush)
        {
            IsChecked = crush.IsSelected;
            CrushName = crush.CrushName;
            string imagePath = crush.IconPath;
            Image = imagePath;
        }

        #region Переменные
        private string crushName;
        public string CrushName
        {
            get { return crushName; }
            set
            {
                crushName = value;
                OnPropertyChanged();
            }
        }

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Команды
        #endregion
    }
}
