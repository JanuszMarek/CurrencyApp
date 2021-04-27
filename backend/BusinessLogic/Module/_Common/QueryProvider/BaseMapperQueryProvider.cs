using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entity.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.Module._Common.QueryProvider
{
    public interface IBaseMapperQueryProvider<T>: IBaseQueryProvider<T> where T : class
    {
    }

    public abstract class BaseMapperQueryProvider<T> : BaseQueryProvider<T> where T : class
    {
        protected readonly IMapper mapper;

        public BaseMapperQueryProvider(CurrencyContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        protected IQueryable<TDest> GetQuery<TDest>(Expression<Func<T, bool>> wherePredict, bool asNoTracking = false, Expression<Func<T, bool>> orderPredict = null, bool orderDesc = false) where TDest: class
        {
            return GetQuery(wherePredict, asNoTracking, orderPredict, orderDesc).ProjectTo<TDest>(mapper.ConfigurationProvider);
        }
    }
}
