using AutoMapper;

namespace InformacionCiudades.API.AutoMapperProfiles
{
    public class CiudadProfile : Profile
    {
        public CiudadProfile()
        {
            CreateMap<Entities.Ciudad, Models.CiudadSinPuntosDeInteresDto>();
            CreateMap<Entities.Ciudad, Models.CiudadDto>();
        }
    }
}
