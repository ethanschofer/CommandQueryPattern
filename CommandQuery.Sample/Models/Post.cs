using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandQuery.Sample.Models
{
    public class Post : TrackUpdate, IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Guid BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}