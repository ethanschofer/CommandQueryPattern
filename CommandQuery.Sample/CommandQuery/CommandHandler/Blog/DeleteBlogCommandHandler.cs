using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Blog
{
    public class DeleteBlogCommandHandler : ICommandHandlerAsync<DeleteBlog>
    {
        public Task<CommandResult> ExecuteAsync(DeleteBlog command)
        {
            throw new NotImplementedException();
        }
    }
}