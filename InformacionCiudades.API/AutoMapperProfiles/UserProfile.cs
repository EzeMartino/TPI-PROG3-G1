using AutoMapper;

namespace Contents.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Entities.User, Models.UserCreationDto>();
            CreateMap<Entities.User, Models.UserWithoutContentsDto>();
        }
    }
}
