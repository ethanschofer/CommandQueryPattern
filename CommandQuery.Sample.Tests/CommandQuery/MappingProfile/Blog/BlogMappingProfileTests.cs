using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using CommandQuery.Sample.CQRS.QueryResult.Post;
using CommandQuery.Sample.Models;
using System.Linq;

namespace CommandQuery.Sample.Tests.CQRS.MappingProfile.Blog
{
    [TestClass]
    public class BlogMappingProfileTests
    {
        [TestMethod]
        public void CreateMap_BlogToBlogListItem_IsValid()
        {
            Mapper.CreateMap<Models.Blog, BlogListItem>()
              .ForMember(dest => dest.NumberOfPosts, opt => opt.MapFrom(src => src.Posts.Count()))
              .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.Posts.Max(p => p.UpdatedDate)));

            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void CreateMap_BlogToBlogQueryResult_IsValid()
        {
            Mapper.CreateMap<Post,PostListItem>()
                .ForMember(dest => dest.NumberOfComments, opt => opt.MapFrom(src => src.Comments.Count()));

            Mapper.CreateMap<Models.Blog, BlogQueryResult>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}