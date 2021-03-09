using System.ComponentModel;

namespace Entity.Enums
{
    public enum SymbolTypesEnum
    {
        [Description(nameof(Currency))]
        Currency = 1,
        [Description(nameof(CryptoCurrency))]
        CryptoCurrency = 2
    }
}
