using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Entities
{
    public class Grafik
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        [Range(0,5,ErrorMessage ="tip 0 5 arası olmalı")]
        public int Tip { get; set; }//0:pie,1bar

        public IEnumerable<GrafikData> GrafikDatas { get; set; }

    }


}
