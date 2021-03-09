using CurrencyApi.EF.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    public class CurrencyDelta
    {
        [ForeignKey(nameof(CurrencyPrice))]
        public long Id { get; set; }

        [Column(TypeName = ColumnTypeName.Delta)]
        public decimal Delta1H { get; set; }

        [Column(TypeName = ColumnTypeName.Delta)]
        public decimal Delta24H { get; set; }

        [Column(TypeName = ColumnTypeName.Delta)]
        public decimal Delta7D { get; set; }

        [Column(TypeName = ColumnTypeName.Delta)]
        public decimal Delta30D { get; set; }

        [Column(TypeName = ColumnTypeName.Price)]
        public decimal Low24H { get; set; }

        [Column(TypeName = ColumnTypeName.Price)]
        public decimal Hight24H { get; set; }

        public CurrencyPrice CurrencyPrice { get; set; }
    }
}
