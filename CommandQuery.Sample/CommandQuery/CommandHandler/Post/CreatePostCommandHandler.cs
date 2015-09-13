using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command.Post;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Post
{
    public class CreatePostCommandHandler : ICommandHandlerAsync<CreatePost>
    {
        public Task<CommandResult> ExecuteAsync(CreatePost command)
        {
            throw new NotImplementedException();
        }
    }
}