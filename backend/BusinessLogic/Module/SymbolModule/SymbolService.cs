using BusinessLogic.CommonModels;
using BusinessLogic.Module.SymbolModule.QueryProvider;
using Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module.SymbolModule
{
    public interface ISymbolService
    {
        Task<IEnumerable<LookupModel>> GetCryptoSymbolsAsync();
    }

    public class SymbolService : ISymbolService
    {
        private readonly ISymbolQueryProvider queryProvider;

        public SymbolService(ISymbolQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
        }


        public async Task<IEnumerable<LookupModel>> GetCryptoSymbolsAsync()
        {
            return await queryProvider.GetSymbolsLookupAsync(SymbolTypesEnum.Cryptocurrency);
        }
    }
}
