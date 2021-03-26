using AutoMapper;
using BusinessLogic.CommonModels;
using BusinessLogic.Module._Common.QueryProvider;
using Entity.Context;
using Entity.Entities;
using Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module.SymbolModule.QueryProvider
{
    public interface ISymbolQueryProvider: IBaseMapperQueryProvider<Symbol>
    {
        Task<IEnumerable<LookupModel>> GetSymbolsLookupAsync(SymbolTypesEnum symbolType);
    }

    public class SymbolQueryProvider: BaseMapperQueryProvider<Symbol>, ISymbolQueryProvider
    {
        public SymbolQueryProvider(CurrencyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<LookupModel>> GetSymbolsLookupAsync(SymbolTypesEnum symbolType)
        {
            return await GetQuery<LookupModel>(x => x.SymbolTypeId == (int)symbolType).ToListAsync();
        }
    }
}
