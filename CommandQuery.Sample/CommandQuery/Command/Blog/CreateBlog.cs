using CommandQuery.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandQuery.Sample.CQRS.Command
{
    public class CreateBlog : ICommand
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}