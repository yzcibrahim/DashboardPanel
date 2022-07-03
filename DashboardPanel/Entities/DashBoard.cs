using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Entities
{
    public class DashBoard
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public IEnumerable<DashBoardWidget> DashBoardWidgets { get; set; }
    }

    public class DashBoardWidget
    {
        public int Id { get; set; }
        public int DashId { get; set; }
        public int GrafikId { get; set; }

        public string Height { get; set; }
        public string Width { get; set; }
        public string Top { get; set; }
        public string Left { get; set; }


        [NotMapped]
        public string HeightPx { 
            get {
                if (Graf.Tip == 0)
                {
                    if (Convert.ToDouble(Height) < Convert.ToDouble(Width))
                        return Height ;
                    else
                        return Width ;

                }
                return Height;
            } 
        }
        [NotMapped]
        public string WidthPx
        {
            get
            {
                if(Graf.Tip==0)
                {
                    if (Convert.ToDouble(Height) < Convert.ToDouble(Width))
                        return Height;
                    else
                        return Width;

                }
                
                    return Width;
            }
        }
        [NotMapped]
        public string TopPx
        {
            get
            {
                return Top + "px";
            }
        }
        [NotMapped]
        public string LeftPx
        {
            get
            {
                return Left + "px";
            }
        }

        [ForeignKey("DashId")]
        public virtual DashBoard Dash { get; set; }

        [ForeignKey("GrafikId")]
        public virtual Grafik Graf { get; set; }
    }
}
