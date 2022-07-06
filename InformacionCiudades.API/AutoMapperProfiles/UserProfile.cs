using AutoMapper;
using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserCreationDto>();
            CreateMap<User, UserWithoutContentsDto>();
            CreateMap<UserCreationDto, User>();
        }
    }
}
