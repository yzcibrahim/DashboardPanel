using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Models
{
    public class DashWidModel
    {
        public string Isim { get; set; }

        public int DashId { get; set; }
        public List<WidgetObj> WidList { get; set; }
    }

    public class WidgetObj 
    {
        public int WidgetId { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Left { get; set; }
        public string Top { get; set; }
    }
}
