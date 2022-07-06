using AutoMapper;
using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.AutoMapperProfiles
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentDto>();
            CreateMap<Content, ContentCreationDto>();
            CreateMap<Content, ContentUpdateDto>();
            CreateMap<ContentCreationDto, Content>();
            CreateMap<ContentDto, Content>();
            CreateMap<ContentUpdateDto, Content>();
        }
    }
}
