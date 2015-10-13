using AutoMapper;
using CommandQuery.Sample.CQRS.Command;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using System;
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

            CreateMap<CreateBlog, Models.Blog>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
                
        }
    }
}