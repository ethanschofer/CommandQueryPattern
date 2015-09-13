using AutoMapper;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using System.Linq;

namespace CommandQuery.Sample.CQRS.MappingProfile.Blog
{
    public class BlogMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Models.Blog, BlogListItem>()
              .ForMember(dest => dest.NumberOfPosts, opt => opt.MapFrom(src => src.Posts.Count()))
              .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.Posts.Max(p => p.UpdatedDate)));
        }
    }
}