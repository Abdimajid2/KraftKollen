using AutoMapper;
using KraftKollen.Models;
using KraftKollen.Repository.Models;

namespace KraftKollen.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WindPowerProductionDTO, WindPowerProduction>()
                    .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src =>
                        src.values != null && src.values.Any() ? src.values.First().municipality : null))
                    .ForMember(dest => dest.Period, opt => opt.MapFrom(src =>
                        src.values != null && src.values.Any() ? src.values.First().period : 0))
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src =>
                        src.values != null && src.values.Any() && src.values.First().values.Any() ?
                        src.values.First().values.First().value : (double?)null));
        }
    }
}

