using CalendarPract6.Model;
using CalendarPract6.ViewModel.CardsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CalendarPract6.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для CrushView.xaml
    /// </summary>
    public partial class CrushView : UserControl
    {
        public string CrushName { get; set; }
        public bool IsChecked {  get; set; }
        public string Image { get; set; }



        public CrushView()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
