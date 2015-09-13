using AutoMapper;
using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Query;
using CommandQuery.Sample.CQRS.QueryResult.Blog;
using CommandQuery.Sample.DataAccess;
using CommandQuery.Sample.Utilities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.QueryHandler.Blog
{
    public class BlogsQueryHandler : IQueryHandlerAsync<GetBlogs, BlogsQueryResult>
    {
        public IDataContext DataContext { get; set; }
        public IMappingEngine Mapper { get; set; }

        public BlogsQueryHandler(IDataContext dataContext, IMappingEngine mapper)
        {
            DataContext = dataContext;
            Mapper = mapper;
        }

        public async Task<BlogsQueryResult> Retrieve(GetBlogs query)
        {
            Ensure.Argument.Is(query != null);

            // Create the view model query result
            var results = new List<BlogListItem>();

            // Pull the required item from the cont.ext
            var blogs = await DataContext.Blogs.Include(b => b.Posts).ToListAsync();
            if (!blogs.Any()) return new BlogsQueryResult(results);

            Mapper.Map(blogs, results);

            foreach(var item in results)
            {
                var blog = blogs.FirstOrDefault(b => b.Id == item.Id);
                item.NumberOfPosts = blog.Posts.Count();
                item.UpdatedDate = blog.Posts.Max(b => b.UpdatedDate);
            }

            return new BlogsQueryResult(results);
        }
    }
}