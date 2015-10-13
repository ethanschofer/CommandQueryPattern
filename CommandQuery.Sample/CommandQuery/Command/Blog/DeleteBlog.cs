using CommandQuery.Core;
using System;

namespace CommandQuery.Sample.CommandQuery.Command
{
    public class DeleteBlog : ICommand
    {
        public Guid ID { get; set; }
    }
}