using AutoMapper;
using BusinessLogic.Module.CurrencyPriceModule.QueryProvider;
using BusinessLogic.Module.SymbolModule;
using Entity.Entities;
using ExternalServices.Models.CoinLib;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ISymbolService symbolService;
        private readonly IMapper mapper;

        public CurrencyPriceService(
            ICurrencyPriceQueryProvider queryProvider, 
            ISymbolService symbolService, 
            IMapper mapper)
        {
            this.queryProvider = queryProvider;
            this.symbolService = symbolService;
            this.mapper = mapper;
        }

        public async Task AddCurrencyPricesAsync(IEnumerable<CoinModel> models)
        {
            var symbols = await symbolService.GetCryptoSymbolsAsync();
            var prices = mapper.Map<IEnumerable<CurrencyPrice>>(models);

            foreach (var price in prices)
            {
                price.Symbol = symbols.Where(x => x.Code == price.Symbol?.Code).FirstOrDefault();
            }
            await AddCurrencyPricesAsync(prices);
        }

        public async Task AddCurrencyPricesAsync(IEnumerable<CurrencyPrice> prices)
        {
            await queryProvider.AddRangeAsync(prices);
            await queryProvider.SaveChangesAsync();
        }
    }
}
