namespace CommandQuery.Core
{
    /// <summary>
    /// An interface for command handlers. All command handlers must implement this
    /// </summary>
    /// <typeparam name="TParameter">The type of command that this handler can handle</typeparam>
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        CommandResult Execute(TParameter command);
    }
}