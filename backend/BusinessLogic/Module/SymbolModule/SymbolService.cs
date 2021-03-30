using BusinessLogic.CommonModels;
using BusinessLogic.Module.SymbolModule.QueryProvider;
using Entity.Entities;
using Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module.SymbolModule
{
    public interface ISymbolService
    {
        Task<IEnumerable<Symbol>> GetCryptoSymbolsAsync();
    }

    public class SymbolService : ISymbolService
    {
        private readonly ISymbolQueryProvider queryProvider;

        public SymbolService(ISymbolQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }


        public async Task<IEnumerable<Symbol>> GetCryptoSymbolsAsync()
        {
            return await queryProvider.GetSymbolsAsync(SymbolTypesEnum.Cryptocurrency);
        }
    }
}
