using Entity.Entities;
using Entity.Enums;
using Entity.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Entity.Seed
{
    public static class DatabaseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedLookupData(modelBuilder);
            SeedData(modelBuilder);
        }

        private static void SeedLookupData(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEntityData(DatabaseSeedLookupData.GetCollectionSeedFromEnum<SymbolType, SymbolTypesEnum>());
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEntityData(DatabaseSeedData.SymbolsSeed());
        }
    }
}
