using AutoMapper;
using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewCreationDto, Review>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewUpdateDto, Review>();
        }
    }
}

