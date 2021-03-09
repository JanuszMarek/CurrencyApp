using Entity.Entities;
using Entity.Seed;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Symbol> Symbols { get; set; }
        public virtual DbSet<SymbolType> SymbolTypes { get; set; }
        public virtual DbSet<CurrencyPrice> CurrencyPrices { get; set; }
        public virtual DbSet<CurrencyDelta> CurrencyDeltas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //DatabaseSeed.Seed(modelBuilder);
        }
    }
}
