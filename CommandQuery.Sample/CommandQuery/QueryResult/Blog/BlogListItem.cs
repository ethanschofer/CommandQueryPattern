using System;
using System.ComponentModel.DataAnnotations;

namespace CommandQuery.Sample.CQRS.QueryResult.Blog
{
    public class BlogListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Number Of Posts")]
        public int NumberOfPosts { get; set; }

        [Display(Name = "Date Last Updated")]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }
    }
}