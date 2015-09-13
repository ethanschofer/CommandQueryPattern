using Autofac;
using System;
using System.Threading.Tasks;

namespace CommandQuery.Core
{
    /// <summary>
    /// Executes a query and return the results of the query
    /// </summary>
    public class QueryDispatcher : IQueryDispatcher
    {
        /// <summary>
        /// The autofac container
        /// </summary>
        private readonly IComponentContext container;

        /// <summary>
        /// Get the container at construction
        /// </summary>
        /// <param name="container"></param>
        public QueryDispatcher(IComponentContext container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        /// <summary>
        /// Execute a query
        /// </summary>
        /// <typeparam name="TParameter">The parameter must be an IQuery</typeparam>
        /// <typeparam name="TResult">The result must be an IQueryResult</typeparam>
        /// <param name="query">The query to execute</param>
        /// <returns>The result of the query</returns>
        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            //Get the approproprite command handler by resolving it from the autofac container based on the IQuery and IQueryResult
            var handler = container.Resolve<IQueryHandlerAsync<TParameter, TResult>>();
            return await handler.Retrieve(query);
        }

        /// <summary>
        /// Execute a query
        /// </summary>
        /// <typeparam name="TParameter">The parameter must be an IQuery</typeparam>
        /// <typeparam name="TResult">The result must be an IQueryResult</typeparam>
        /// <param name="query">The query to execute</param>
        /// <returns>The result of the query</returns>
        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            //Get the approproprite command handler by resolving it from the autofac container based on the IQuery and IQueryResult
            var handler = container.Resolve<IQueryHandler<TParameter, TResult>>();
            return handler.Retrieve(query);
        }
    }
}