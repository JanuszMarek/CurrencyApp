using BusinessLogic.Module._Common.QueryProvider;
using Entity.Context;
using Entity.Entities;

namespace BusinessLogic.Module.CurrencyPriceModule.QueryProvider
{
    public interface ICurrencyPriceQueryProvider : IBaseQueryProvider<CurrencyPrice>
    {
    }

    public class CurrencyPriceQueryProvider : BaseQueryProvider<CurrencyPrice>, ICurrencyPriceQueryProvider
    {
        public CurrencyPriceQueryProvider(CurrencyContext context) : base(context)
        {
        }
    }
}
