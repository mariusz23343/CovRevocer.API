using Application.Posts;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Post, Post>();
            CreateMap<Post, PostDto>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
