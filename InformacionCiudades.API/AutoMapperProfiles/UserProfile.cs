using AutoMapper;
using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
<<<<<<< HEAD
            CreateMap<User, UserDto>();
            CreateMap<User, UserCreationDto>();
=======
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Entities.User, Models.UserCreationDto>();
            CreateMap<Entities.User, Models.UserWithoutContentsDto>();
>>>>>>> a3a54b705612e16dbc04bce01b2bc96d3fe3916c
        }
    }
}
