using CommandQuery.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandQuery.Sample.CQRS.QueryResult.Blog
{
    public class BlogsQueryResult : Collection<BlogListItem>, IQueryResult
    {
        public BlogsQueryResult(IList<BlogListItem> results)
            : base(results)
        { }
    }
}