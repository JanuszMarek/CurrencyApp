using AutoMapper;
using BusinessLogic.Module.CurrencyPriceModule.QueryProvider;
using Entity.Entities;
using ExternalServices.Models.CoinLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module.CurrencyPriceModule
{
    public interface ICurrencyPriceService
    {
        Task AddCurrencyPricesAsync(IEnumerable<CoinModel> models);
        Task AddCurrencyPricesAsync(IEnumerable<CurrencyPrice> prices);
    }

    public class CurrencyPriceService : ICurrencyPriceService
    {
        private readonly ICurrencyPriceQueryProvider queryProvider;
        private readonly IMapper mapper;

        public CurrencyPriceService(ICurrencyPriceQueryProvider queryProvider, IMapper mapper)
        {
            this.queryProvider = queryProvider;
            this.mapper = mapper;
        }

        public async Task AddCurrencyPricesAsync(IEnumerable<CoinModel> models)
        {
            var prices = mapper.Map<IEnumerable<CurrencyPrice>>(models);
            await AddCurrencyPricesAsync(prices);
        }

        public async Task AddCurrencyPricesAsync(IEnumerable<CurrencyPrice> prices)
        {
            await queryProvider.AddRangeAsync(prices);
            await queryProvider.SaveChangesAsync();
        }
    }
}
