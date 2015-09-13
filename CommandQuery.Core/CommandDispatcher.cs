using Autofac;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Core
{
    /// <summary>
    /// Executes a command and returns a command result
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        //The autofac container for getting registered commands
        private readonly IComponentContext container;

        /// <summary>
        /// Get the container at construction
        /// </summary>
        /// <param name="container"></param>
        public CommandDispatcher(IComponentContext container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        /// <summary>
        /// Execute the command async
        /// </summary>
        /// <typeparam name="TParameter">The parameter type must be an ICommand</typeparam>
        /// <param name="command">The command to execute</param>
        /// <returns>Returns a command result</returns>
        public async Task<CommandResult> DispatchAsync<TParameter>(TParameter command) where TParameter : ICommand
        {
            //Get the approproprite command handler by resolving it from the autofac container based on the ICommand
            var handler = container.Resolve<ICommandHandlerAsync<TParameter>>();
            return await handler.ExecuteAsync(command);
        }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <typeparam name="TParameter">The parameter type must be an ICommand</typeparam>
        /// <param name="command">The command to execute</param>
        /// <returns>Returns a command result</returns>
        public CommandResult Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            //Get the approproprite command handler by resolving it from the autofac container based on the ICommand
            var handler = container.Resolve<ICommandHandler<TParameter>>();
            return handler.Execute(command);
        }
    }
}