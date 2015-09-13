namespace CommandQuery.Core
{
    /// <summary>
    /// A command result. All commands must return a command result
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// The status of the outcome of the command
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// A message regarding the command
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Any data returned by the command
        /// </summary>
        public object Data { get; set; }
    }
}