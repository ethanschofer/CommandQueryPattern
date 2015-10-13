using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CommandQuery.Sample.CQRS.Query.Blog;
using CommandQuery.Sample.CQRS.QueryHandler.Blog;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using CommandQuery.Sample.CQRS.QueryResult.Post;
using CommandQuery.Sample.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQuery.Sample.Tests.CommandQuery.QueryHandler.Blog
{
    [TestClass]
    public class BlogQueryHandlerTests
    {
        private static IDataContext Context { get; set; }
        private static Mock<IMappingEngine> Mapper { get; set; }

        public static Guid blogId1 { get; set; }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            Context = new TestDataContext();

            blogId1 = Guid.NewGuid();

            var posts1 = new List<Models.Post>()
            {
                new Models.Post { Id = Guid.NewGuid(), BlogId = blogId1, Title = "TestPost1", Content = "TestContent1", Author = new Models.Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst1", LastName = "AuthorLast1" } },
                new Models.Post { Id = Guid.NewGuid(), BlogId = blogId1, Title = "TestPost2", Content = "TestContent2", Author = new Models.Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst2", LastName = "AuthorLast2" } },
                new Models.Post { Id = Guid.NewGuid(), BlogId = blogId1, Title = "TestPost3", Content = "TestContent3", Author = new Models.Author() { Id = Guid.NewGuid(), FirstName = "AuthorFirst3", LastName = "AuthorLast3" } },
            };

            var blog1 = new Models.Blog { Id = blogId1, Name = "BlogName1", Posts = posts1 };

            Context.Blogs.Add(blog1);

            var blogQueryResult = new BlogQueryResult
            {
                Id = blogId1,
                Name = "BlogName1",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Posts = new List<PostListItem>() 
                {
                    new PostListItem() { Id = Guid.NewGuid(), Title = "TestPost1", Content = "TestContent1", AuthorName = "AuthorFirst1 AuthorLast1", NumberOfComments = 3, PostDate = DateTime.Now },
                    new PostListItem() { Id = Guid.NewGuid(), Title = "TestPost2", Content = "TestContent2", AuthorName = "AuthorFirst2 AuthorLast2", NumberOfComments = 2, PostDate = DateTime.Now },
                    new PostListItem() { Id = Guid.NewGuid(), Title = "TestPost3", Content = "TestContent3", AuthorName = "AuthorFirst3 AuthorLast3", NumberOfComments = 1, PostDate = DateTime.Now }
                }
            };

            Mapper = new Mock<IMappingEngine>();
            Mapper.Setup(m => m.Map<Models.Blog, BlogQueryResult>(It.IsAny<Models.Blog>(), It.IsAny<BlogQueryResult>())).Returns(blogQueryResult);
        }

        [TestMethod]
        public async Task Retrieve_RequestPages_QueryResultReturned()
        {
            var handler = new BlogQueryHandler(Context, Mapper.Object);
            var query = new GetBlog(blogId1);
            var result = await handler.Retrieve(query);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BlogQueryResult));

            Assert.AreEqual(blogId1, result.Id);            
        }

        [TestMethod]
        public async Task Retrieve_RequestNonExistentBlog_EmptyResultReturned()
        {
            var handler = new BlogQueryHandler(Context, Mapper.Object);
            var query = new GetBlog(Guid.NewGuid());
            var result = await handler.Retrieve(query);
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Retrieve_RequestNull_Exception()
        {
            var handler = new BlogQueryHandler(Context, Mapper.Object);
            var result = await handler.Retrieve(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task Retrieve_RequestEmptyGuidSiteID_Exception()
        {
            var handler = new BlogQueryHandler(Context, Mapper.Object);
            var query = new GetBlog(Guid.Empty);
            var result = await handler.Retrieve(query);
        }        
    }
}
