namespace CommandQuery.Core
{
    /// <summary>
    /// An interface for query handlers
    /// </summary>
    /// <typeparam name="TParameter">The type of query that the handler will accept</typeparam>
    /// <typeparam name="TResult">The type of onject the query will return</typeparam>
    public interface IQueryHandler<TParameter, TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        TResult Retrieve(TParameter query);
    }
}