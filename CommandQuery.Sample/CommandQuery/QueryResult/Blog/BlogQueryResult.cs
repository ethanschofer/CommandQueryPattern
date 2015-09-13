using CommandQuery.Core;
using CommandQuery.Sample.CQRS.QueryResult.Post;
using CommandQuery.Sample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandQuery.Sample.CQRS.QueryResult.Blog
{
    public class BlogQueryResult : IQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostListItem> Posts { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}