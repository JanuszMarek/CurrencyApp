using Entity.Entities;
using Entity.Enums;
using System.Collections.Generic;

namespace Entity.Seed
{
    public static class DatabaseSeedData
    {
        public static IEnumerable<Symbol> SymbolsSeed()
        {
            return new List<Symbol>() {
                new Symbol() { Id = 1, Code = "USD", Name = "United States Dollar", SymbolTypeId = (int)SymbolTypesEnum.Currency },
                new Symbol() { Id = 2, Code = "EUR", Name = "Euro", SymbolTypeId = (int)SymbolTypesEnum.Currency },
                new Symbol() { Id = 3, Code = "GBP", Name = "British Pound", SymbolTypeId = (int)SymbolTypesEnum.Currency },
                new Symbol() { Id = 4, Code = "BTC", Name = "Bitcoin", SymbolTypeId = (int)SymbolTypesEnum.Cryptocurrency },
                new Symbol() { Id = 5, Code = "ETH", Name = "Etherum", SymbolTypeId = (int)SymbolTypesEnum.Cryptocurrency },
                new Symbol() { Id = 6, Code = "USDT", Name = "Tether", SymbolTypeId = (int)SymbolTypesEnum.Cryptocurrency }
            };
        }
    }
}
