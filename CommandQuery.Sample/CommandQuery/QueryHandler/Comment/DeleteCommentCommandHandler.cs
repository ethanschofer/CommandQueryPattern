using CommandQuery.Core;
using CommandQuery.Sample.CQRS.Command.Comment;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Sample.CQRS.CommandHandler.Comment
{
    public class DeleteCommentCommandHandler : ICommandHandlerAsync<DeleteComment>
    {
        public Task<CommandResult> ExecuteAsync(DeleteComment command)
        {
            throw new NotImplementedException();
        }
    }
}