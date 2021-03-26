using AutoMapper;
using BusinessLogic.CommonModels;
using Entity.Entities;

namespace BusinessLogic.Module.SymbolModule.MapperProfile
{
    public class SymbolProfile : Profile
    {
        public SymbolProfile()
        {

        }

        public void MapModelToEntityM()
        {
            CreateMap<Symbol, LookupModel>()
                .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Label, opt => opt.MapFrom(src => src.Code));
        }
    }


}
