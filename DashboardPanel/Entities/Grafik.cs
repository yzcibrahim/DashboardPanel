using DashboardPanel.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Entities
{
    public class Grafik
    {
        public int Id { get; set; }
        public string Isim { get; set; }

        [Range(0, 5, ErrorMessage = "tip 0 5 arası olmalı")]
        [TipRequired]
        public int Tip { get; set; } = -1;//0:pie,1bar

        [TipRequired]
        public int WidgetTip { get; set; } = -1;

        [SqlQueryRequired]
        public string SqlQuery { get; set; }


        [NotMapped]
        public string TipAciklama
        {
            get
            {
                switch (Tip)
                {
                    case 0:
                        return "Pie";
                    case 1:
                        return "Bar";
                    case 2:
                        return "Line";
                   
                }

                return "";
            }
        }

        [NotMapped]
        public string WidgetTipAciklama
        {
            get
            {
                switch (WidgetTip)
                {
                    case 0:
                        return "Statik";
                    case 1:
                        return "Sql Sorgu";

                }

                return "";
            }
        }

        public IEnumerable<GrafikData> GrafikDatas { get; set; }

    }






}
