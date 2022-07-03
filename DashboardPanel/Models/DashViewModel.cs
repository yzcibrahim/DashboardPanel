using DashboardPanel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Models
{
    public class DashViewModel
    {
        public List<Grafik> Widgets { get; set; }

        public DashBoard Dash { get; set; }
    }
}
