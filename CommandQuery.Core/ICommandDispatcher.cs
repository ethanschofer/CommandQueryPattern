using System.Threading.Tasks;

namespace CommandQuery.Core
{
    /// <summary>
    /// An interface for he command dispatcher
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Execute the command async
        /// </summary>
        /// <typeparam name="TParameter">The parameter type must be an ICommand</typeparam>
        /// <param name="command">The command to execute</param>
        /// <returns>Returns a command result</returns>
        Task<CommandResult> DispatchAsync<TParameter>(TParameter command) where TParameter : ICommand;

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <typeparam name="TParameter">The parameter type must be an ICommand</typeparam>
        /// <param name="command">The command to execute</param>
        /// <returns>Returns a command result</returns>
        CommandResult Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}