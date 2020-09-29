using Data.Abstractions.Interfaces;
using Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class DbContext : IDbContext
    {
        private readonly IDataConnection<SqlConnection> _connection;
        private readonly ILoggerFactory _loggerFactory;
        private IArea57Repository _area57Repository;

        public DbContext(SqlDataConnection connection, ILoggerFactory loggerFactory)
        {
            _connection = connection;
            _loggerFactory = loggerFactory;
        }

        public IArea57Repository Area57Repository => _area57Repository ?? (_area57Repository = 
            new Area57Repository(_connection, _loggerFactory.CreateLogger<Area57Repository>()));
    

        public Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
        {
            return _connection.CanConnectAsync(cancellationToken);
        }

        public Task<IDataConnectionTransaction> BeginTransaction(IsolationLevel isolationLevel)
        {
            return _connection.BeginTransaction(isolationLevel);
        }

        public Task<IDataConnectionTransaction> BeginTransaction()
        {
            return _connection.BeginTransaction();
        }
    }
}
