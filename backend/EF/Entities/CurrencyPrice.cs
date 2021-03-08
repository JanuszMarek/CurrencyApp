using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    public class CurrencyPrice
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Symbol))]
        public int SymbolId { get; set; }

        public decimal Price { get; set; }

        public DateTime Timestamp { get; set; }

        public Symbol Symbol { get; set; }

        public CurrencyDelta CurrencyDelta { get; set; }

    }
}
