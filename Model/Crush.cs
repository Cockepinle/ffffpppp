using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPract6.Model
{
    public class Crush
    {
        public string CrushName { get; set; }  
        public string IconPath { get; set;}
        public bool IsSelected { get; set; }

        public Crush(string crushname, string iconpath, bool isselected)
        {
            this.CrushName = crushname;
            this.IconPath = iconpath;
            this.IsSelected = isselected;
        }

    }
}
