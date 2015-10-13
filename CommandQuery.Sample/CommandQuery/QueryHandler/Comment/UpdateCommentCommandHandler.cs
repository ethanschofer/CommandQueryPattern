using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command.Comment;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Comment
{
    public class UpdateCommentCommandHandler : ICommandHandlerAsync<UpdateComment>
    {
        public Task<CommandResult> ExecuteAsync(UpdateComment command)
        {
            throw new NotImplementedException();
        }
    }
}