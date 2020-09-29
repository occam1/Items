using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Serilog;
using System.Threading.Tasks;
using System.Threading;

namespace Data.Abstractions.Interfaces
{
    public interface IDbContext
    {
        IArea57Repository Area57Repository { get; }
        /// <summary>
        /// This will test if a connnectoin can be opened to the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>This returns true if a connection to the database can be opened</returns>

        public Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);

        Task<IDataConnectionTransaction> BeginTransaction(IsolationLevel isolationLevel);

        Task<IDataConnectionTransaction> BeginTransaction();

    }
}
