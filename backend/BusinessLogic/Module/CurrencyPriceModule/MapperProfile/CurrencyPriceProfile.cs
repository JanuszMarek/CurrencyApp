using AutoMapper;
using Entity.Entities;
using ExternalServices.Models.CoinLib;
using System;

namespace BusinessLogic.Module.CurrencyPriceModule.MapperProfile
{
    public class CurrencyPriceProfile : Profile
    {

        public CurrencyPriceProfile()
        {
            MapModelToEntity();
        }

        public void MapModelToEntity()
        {
            CreateMap<CoinModel, CurrencyPrice>()
                .ForMember(dst => dst.SymbolId, opt => opt.Ignore())
                .ForMember(dst => dst.Symbol, opt => opt.MapFrom(src => src))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dst => dst.Timestamp, opt => opt.MapFrom(src => 
                    DateTimeOffset.FromUnixTimeSeconds(src.LastUpdatedTimestamp).DateTime))
                .ForMember(dst => dst.CurrencyDelta, opt => opt.MapFrom(src => src));

            CreateMap<CoinModel, CurrencyDelta>()
                .ForMember(dst => dst.Delta1H, opt => opt.MapFrom(src => src.Delta1h))
                .ForMember(dst => dst.Delta24H, opt => opt.MapFrom(src => src.Delta24h))
                .ForMember(dst => dst.Delta7D, opt => opt.MapFrom(src => src.Delta7d))
                .ForMember(dst => dst.Delta30D, opt => opt.MapFrom(src => src.Delta30d))
                .ForMember(dst => dst.Low24H, opt => opt.MapFrom(src => src.Low24h))
                .ForMember(dst => dst.Hight24H, opt => opt.MapFrom(src => src.High24h));

            CreateMap<CoinModel, Symbol>()
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dst => dst.Name, opt => opt.Ignore())
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.SymbolTypeId, opt => opt.Ignore())
                .ForMember(dst => dst.SymbolType, opt => opt.Ignore());

        }
    }
}
