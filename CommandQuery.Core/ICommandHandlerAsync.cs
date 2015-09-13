using System.Threading.Tasks;

namespace CommandQuery.Core
{
    /// <summary>
    /// An interface for async command handlers. All command handlers must implement this
    /// </summary>
    /// <typeparam name="TParameter">The type of command that this handler can handle</typeparam>
    public interface ICommandHandlerAsync<in TParameter> where TParameter : ICommand
    {
        Task<CommandResult> ExecuteAsync(TParameter command);
    }
}