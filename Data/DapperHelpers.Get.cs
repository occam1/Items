using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Data.Abstractions.Interfaces;

namespace Data
{
    public static partial class DapperHelpers
    {
        /// <summary>
        /// Execute a query asynchronously using .NET 4.5 Task.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <typeparam name="TConn"></typeparam>
        /// <param name="cnn">The connection to query on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// A sequence of data of <typeparamref name="T"/>; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        public static async Task<IEnumerable<T>> GetAsync<T, TConn>(this IDataConnection<TConn> cnn, string sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default) where TConn : IDbConnection
        {
            var timeout = commandTimeout ?? cnn.DefaultCommandTimeout;
            var connection = await cnn.GetOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
            var retryPolicy = cnn.RetryPolicy?.GetStandardRetryPolicy();
            transaction = transaction ?? cnn.CurrentTransaction;
            try
            {
                var result = await QueryAsync<T>(connection, sql, param, transaction, timeout, commandType, retryPolicy,
                cancellationToken).ConfigureAwait(false);

                return result;

            }
            catch (Exception ex)
            { throw ex; }
         
        }

        /// <summary>
        /// Execute a single-row query asynchronously using .NET 4.5 Task.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <typeparam name="TConn"></typeparam>
        /// <param name="cnn">The connection to query on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<T> GetFirstOrDefaultAsync<T, TConn>(this IDataConnection<TConn> cnn,
            string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default) where TConn : IDbConnection
        {
            var timeout = commandTimeout ?? cnn.DefaultCommandTimeout;
            var connection = await cnn.GetOpenConnectionAsync(cancellationToken).ConfigureAwait(false);
            var retryPolicy = cnn.RetryPolicy?.GetStandardRetryPolicy();
            transaction = transaction ?? cnn.CurrentTransaction;

            return await QueryFirstOrDefaultAsync<T>(connection, sql, param, transaction, timeout, commandType, retryPolicy,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
