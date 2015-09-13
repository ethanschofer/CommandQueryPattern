using System;

namespace CommandQuery.Sample.Models
{
    public class Comment : TrackUpdate, IEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}