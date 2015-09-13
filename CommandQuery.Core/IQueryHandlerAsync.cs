using System.Threading.Tasks;

namespace CommandQuery.Core
{
    /// <summary>
    /// An interface for async query handlers
    /// </summary>
    /// <typeparam name="TParameter">The type of query that the handler will accept</typeparam>
    /// <typeparam name="TResult">The type of onject the query will return</typeparam>
    public interface IQueryHandlerAsync<TParameter, TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        Task<TResult> Retrieve(TParameter query);
    }
}