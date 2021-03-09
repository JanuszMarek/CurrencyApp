using Entity.Entities;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Seed
{
    public static class DatabaseSeedData
    {
        public static IEnumerable<Symbol> SymbolsSeed()
        {
            return new List<Symbol>() {
                new Symbol() { Id = 1, Code = "USD", Name = "United States dollar", SymbolTypeId = (int)SymbolTypesEnum.Currency },
                new Symbol() { Id = 2, Code = "EUR", Name = "Eur", SymbolTypeId = (int)SymbolTypesEnum.Currency },
                new Symbol() { Id = 3, Code = "GBP", Name = "British Pound", SymbolTypeId = (int)SymbolTypesEnum.Currency },
                new Symbol() { Id = 4, Code = "BTC", Name = "Bitcoin", SymbolTypeId = (int)SymbolTypesEnum.CryptoCurrency },
                new Symbol() { Id = 5, Code = "ETH", Name = "Etherum", SymbolTypeId = (int)SymbolTypesEnum.CryptoCurrency },
                new Symbol() { Id = 6, Code = "USDT", Name = "Tether", SymbolTypeId = (int)SymbolTypesEnum.CryptoCurrency }
            };
        }
    }
}
