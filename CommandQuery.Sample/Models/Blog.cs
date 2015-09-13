using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandQuery.Sample.Models
{
    public class Blog : TrackUpdate, IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}