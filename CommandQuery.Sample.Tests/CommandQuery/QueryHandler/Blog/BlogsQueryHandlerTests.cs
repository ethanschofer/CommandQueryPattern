using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CommandQuery.Sample.CQRS.Query;
using CommandQuery.Sample.CQRS.QueryHandler.Blog;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using CommandQuery.Sample.DataAccess;
using CommandQuery.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandQuery.Sample.Tests.CommandQuery.QueryHandler.Blog
{
    [TestClass]
    public class BlogsQueryHandlerTests
    {
        private static IDataContext Context { get; set; }
        private static Mock<IMappingEngine> Mapper { get; set; }

        public static Guid blogId1 { get; set; }
        public static Guid blogId2 { get; set; }
        public static Guid blogId3 { get; set; }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            Context = new TestDataContext();

            blogId1 = Guid.NewGuid();
            blogId2 = Guid.NewGuid();
            blogId3 = Guid.NewGuid();

            var posts1 = new List<Post>()
            {
                new Post { Id = Guid.NewGuid(), BlogId = blogId1, Title = "TestPost1", Content = "TestContent1", Author = new Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst1", LastName = "AuthorLast1" } },
                new Post { Id = Guid.NewGuid(), BlogId = blogId1, Title = "TestPost2", Content = "TestContent2", Author = new Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst2", LastName = "AuthorLast2" } },
                new Post { Id = Guid.NewGuid(), BlogId = blogId1, Title = "TestPost3", Content = "TestContent3", Author = new Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst3", LastName = "AuthorLast3" } },
            };

            var posts2 = new List<Post>()
            {
                new Post { Id = Guid.NewGuid(), BlogId = blogId2, Title = "TestPost4", Content = "TestContent4", Author = new Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst4", LastName = "AuthorLast4" } },
                new Post { Id = Guid.NewGuid(), BlogId = blogId2, Title = "TestPost5", Content = "TestContent5", Author = new Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst5", LastName = "AuthorLast5" } }
            };

            var posts3 = new List<Post>()
            {
                new Post { Id = Guid.NewGuid(), BlogId = blogId3, Title = "TestPost6", Content = "TestContent6", Author = new Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst6", LastName = "AuthorLast6" } }
            };

            var blog1 = new Models.Blog { Id = blogId1, Name = "BlogName1", Posts = posts1 };
            var blog2 = new Models.Blog { Id = blogId2, Name = "BlogName2", Posts = posts2 };
            var blog3 = new Models.Blog { Id = blogId3, Name = "BlogName3", Posts = posts3 };

            Context.Blogs.Add(blog1);
            Context.Blogs.Add(blog2);
            Context.Blogs.Add(blog3);

            var blogsQueryResult = new List<BlogListItem>
            {
                new BlogListItem { Id = blogId1, Name = "BlogName1", NumberOfPosts = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new BlogListItem { Id = blogId2, Name = "BlogName2", NumberOfPosts = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new BlogListItem { Id = blogId3, Name = "BlogName3", NumberOfPosts = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
            };

            Mapper = new Mock<IMappingEngine>();

            Mapper.Setup(m => m.Map<List<Models.Blog>, List<BlogListItem>>(It.IsAny<List<Models.Blog>>(), It.IsAny<List<BlogListItem>>()))
                                .Callback((List<Models.Blog> blogs, List<BlogListItem> queryResults) =>
                                {
                                    queryResults.AddRange(blogsQueryResult);
                                });
        }

        [TestMethod]
        public async Task Retrieve_RequestActivities_QueryResultReturned()
        {
            var handler = new BlogsQueryHandler(Context, Mapper.Object);
            var query = new GetBlogs();
            var result = await handler.Retrieve(query);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BlogsQueryResult));

            var item = result.FirstOrDefault(r => r.Id == blogId1);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Retrieve_RequestNull_Exception()
        {
            var handler = new BlogsQueryHandler(Context, Mapper.Object);
            var result = await handler.Retrieve(null);
        }
    }
}