using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Blog
{
    public class UpdateBlogCommandHandler : ICommandHandlerAsync<UpdateBlog>
    {
        public Task<CommandResult> ExecuteAsync(UpdateBlog command)
        {
            throw new NotImplementedException();
        }
    }
}