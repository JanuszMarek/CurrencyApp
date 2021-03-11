using BusinessLogic.Module._Common.QueryProvider;
using Entity.Context;
using Entity.Entities;

namespace BusinessLogic.Module.CryptoApi.QueryProvider
{
    public interface ICryptoApiQueryProvider
    {

    }

    public class CryptoApiQueryProvider: BaseQueryProvider<CurrencyPrice>, ICryptoApiQueryProvider
    {
        public CryptoApiQueryProvider(CurrencyContext context) : base(context)
        {
        }


    }
}
