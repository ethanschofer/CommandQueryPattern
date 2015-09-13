using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandQuery.Sample.CQRS.Query.Blog;
using System;

namespace CommandQuery.Sample.Tests.CQRS.Query.Blog
{
    [TestClass]
    public class BlogQueryTests
    {
        public static Guid BlogId { get; set; }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            BlogId = Guid.NewGuid();
        }

        [TestMethod]
        public void Constructor_SetParameters_ParametersSet()
        {
            var getBlog = new GetBlog(BlogId);

            Assert.IsNotNull(getBlog);
            Assert.AreEqual(BlogId, getBlog.BlogId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_UseEmptyGuid_Fails()
        {
            var getBlog = new GetBlog(Guid.Empty);
        }
    }
}