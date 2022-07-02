using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardPanel.Entities
{
    public class GrafikData
    {
        public int Id { get; set; }
        public string Anahtar { get; set; }
        public double Value { get; set; }

        public string ColorCode { get; set; }
        public int? GrafikId { get; set; }

        [ForeignKey("GrafikId")]
        public virtual Grafik Grafik { get; set; }


    }


}
