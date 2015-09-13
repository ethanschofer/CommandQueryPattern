using System.Threading.Tasks;

namespace CommandQuery.Core
{
    /// <summary>
    /// An interface for the query dispatcher that executes queries
    /// </summary>
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Execute the query async
        /// </summary>
        /// <typeparam name="TParameter">The type of query that the query dispatcher will accept</typeparam>
        /// <typeparam name="TResult">The type of output from the query</typeparam>
        /// <param name="query">The query to execute</param>
        /// <returns>The query result</returns>
        Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult;

        /// <summary>
        /// Execute the query
        /// </summary>
        /// <typeparam name="TParameter">The type of query that the query dispatcher will accept</typeparam>
        /// <typeparam name="TResult">The type of output from the query</typeparam>
        /// <param name="query">The query to execute</param>
        /// <returns>The query result</returns>
        TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult;
    }
}