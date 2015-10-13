using CommandQuery.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandQuery.Sample.CommandQuery.Command
{
    public class CreateBlog : ICommand
    {
        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}