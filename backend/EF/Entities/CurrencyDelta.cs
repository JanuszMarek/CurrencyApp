using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    public class CurrencyDelta
    {
        [ForeignKey(nameof(CurrencyPrice))]
        public long Id { get; set; }
        public decimal Delta1H { get; set; }
        public decimal Delta24H { get; set; }
        public decimal Delta7D { get; set; }
        public decimal Delta30D { get; set; }
        public decimal Low24H { get; set; }
        public decimal Hight24H { get; set; }

        public CurrencyPrice CurrencyPrice { get; set; }
    }
}
