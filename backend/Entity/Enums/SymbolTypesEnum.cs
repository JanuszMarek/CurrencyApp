using System.ComponentModel;

namespace Entity.Enums
{
    public enum SymbolTypesEnum
    {
        [Description(nameof(Currency))]
        Currency = 1,
        [Description(nameof(Cryptocurrency))]
        Cryptocurrency = 2
    }
}
