using AutoMapper;

namespace InformacionCiudades.API.AutoMapperProfiles
{
    public class PuntoDeInteresProfile : Profile
    {
        public PuntoDeInteresProfile()
        {
            CreateMap<Entities.PuntoDeInteres, Models.PuntoDeInteresDto>();
            CreateMap<Models.PuntoDeInteresParaCreacionDto, Entities.PuntoDeInteres>();
            CreateMap<Models.PuntoDeInteresParaUpdateDto, Entities.PuntoDeInteres>();
        }
    }
}
