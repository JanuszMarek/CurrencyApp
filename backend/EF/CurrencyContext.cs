using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class CurrencyContext : DbContext
    {
        public virtual DbSet<Symbol> Symbols { get; set; }
        public virtual DbSet<SymbolType> SymbolTypes { get; set; }
        public virtual DbSet<CurrencyPrice> CurrencyPrices { get; set; }
        public virtual DbSet<CurrencyDelta> CurrencyDeltas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
