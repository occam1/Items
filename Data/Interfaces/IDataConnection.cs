using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDataConnection<T> : IDisposable where T : IDbConnection
    {
        /// <summary>
        /// The time in seconds to wait for the command to execute.
        /// </summary>
        int? DefaultCommandTimeout { get; }

        /// <summary>
        /// This is the standard Polly retry policy that each method will use when running 
        /// </summary>
        ISqlPolicyRegistry RetryPolicy { get; }

        /// <summary>
        /// This is the current transaction 
        /// </summary>
        IDbTransaction CurrentTransaction { get; }

        /// <summary>
        /// This will open a connection to the database asynchronously
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>This returns an open connection of type IDbConnection</returns>
        Task<T> GetOpenConnectionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// This will test if a connection can be opened to the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>This returns true if a connection to the database can be opened</returns>
        Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);

        Task<IDataConnectionTransaction> BeginTransaction();

        Task<IDataConnectionTransaction> BeginTransaction(IsolationLevel isolationLevel);

    }
}
