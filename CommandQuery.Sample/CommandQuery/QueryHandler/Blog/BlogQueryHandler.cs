using AutoMapper;
using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Query.Blog;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using CommandQuery.Sample.DataAccess;
using CommandQuery.Sample.Utilities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.QueryHandler.Blog
{
    public class BlogQueryHandler : IQueryHandlerAsync<GetBlog, BlogQueryResult>
    {
        public IDataContext DataContext { get; set; }
        public IMappingEngine Mapper { get; set; }

        public BlogQueryHandler(IDataContext dataContext, IMappingEngine mapper)
        {
            DataContext = dataContext;
            Mapper = mapper;
        }

        public async Task<BlogQueryResult> Retrieve(GetBlog query)
        {
            Ensure.Argument.Is(query != null);
            Ensure.Argument.IsNot(query.BlogId == Guid.Empty);

            // Create the view model query result
            var result = new BlogQueryResult();

            // Pull the required item from the cont.ext
            var blog = await DataContext.Blogs.Include(b => b.Posts).Where(b => b.Id == query.BlogId).FirstOrDefaultAsync();
            if (blog == null) return null;

            result = Mapper.Map(blog, result);

            return result;
        }
    }
}