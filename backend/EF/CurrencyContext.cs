using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class CurrencyContext : DbContext
    {
        private readonly string _connectionString;

        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Symbol> Symbols { get; set; }
        public virtual DbSet<SymbolType> SymbolTypes { get; set; }
        public virtual DbSet<CurrencyPrice> CurrencyPrices { get; set; }
        public virtual DbSet<CurrencyDelta> CurrencyDeltas { get; set; }
    }
}
