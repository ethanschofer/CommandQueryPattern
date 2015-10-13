using CommandQuery.Core;
using System;

namespace CommandQuery.Sample.CommandQuery.Command
{
    public class UpdateBlog : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}