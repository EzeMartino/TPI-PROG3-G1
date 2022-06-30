using AutoMapper;

namespace Contents.API.AutoMapperProfiles
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Entities.Content, Models.ContentDto>();
            CreateMap<Entities.Content, Models.ContentCreationDto>();
            CreateMap<Entities.Content, Models.ContentUpdateDto>();
        }
    }
}
