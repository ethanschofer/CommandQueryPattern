using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommandQuery.Sample.CQRS.QueryResult.Post
{
    public class PostListItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime PostDate { get; set; }
    }
}