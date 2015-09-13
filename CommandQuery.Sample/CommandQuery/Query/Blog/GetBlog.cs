using CommandQuery.Core;
using CommandQuery.Sample.Utilities;
using System;

namespace CommandQuery.Sample.CQRS.Query.Blog
{
    public class GetBlog : IQuery
    {
        public Guid BlogId { get; private set; }

        public GetBlog(Guid blogId)
        {
            Ensure.Argument.IsNot(blogId == Guid.Empty);

            BlogId = blogId;
        }
    }
}