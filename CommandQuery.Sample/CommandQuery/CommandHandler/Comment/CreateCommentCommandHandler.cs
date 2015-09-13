using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command.Comment;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Comment
{
    public class CreateCommentCommandHandler : ICommandHandlerAsync<CreateComment>
    {
        public Task<CommandResult> ExecuteAsync(CreateComment command)
        {
            throw new NotImplementedException();
        }
    }
}