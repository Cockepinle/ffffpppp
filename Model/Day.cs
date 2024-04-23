using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPract6.Model
{
    public class Day
    {
        public DateTime Date { get; set; }
        public ObservableCollection<Crush> Crushes { get; set; }

        public Day(DateTime date, ObservableCollection<Crush> crushes)
        {
            this.Date = date;
            this.Crushes = crushes;
        }
    }
}
