using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Blog
{
    public class CreateBlogCommandHandler : ICommandHandlerAsync<CreateBlog>
    {
        public Task<CommandResult> ExecuteAsync(CreateBlog command)
        {
            throw new NotImplementedException();
        }
    }
}