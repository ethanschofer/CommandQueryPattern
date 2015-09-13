using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command.Post;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Post
{
    public class UpdatePostCommandHandler : ICommandHandlerAsync<UpdatePost>
    {
        public Task<CommandResult> ExecuteAsync(UpdatePost command)
        {
            throw new NotImplementedException();
        }
    }
}