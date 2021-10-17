using Data.Interfaces;
using Microsoft.Extensions.Logging;
using Polly.Registry;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class SqlDataConnection : DataConnection<SqlConnection>
    {
        public SqlDataConnection(
            ConnectionConfig connectionConfig,
            ISqlPolicyRegistry policyRegistry,
            ILogger<SqlDataConnection> logger) : this(ConvertToConnectionString(connectionConfig, logger),policyRegistry, logger)
        {
            DefaultCommandTimeout = connectionConfig.ConnectTimeout;
        }
        public SqlDataConnection(string connectionString,ISqlPolicyRegistry policyRegistry, ILogger<SqlDataConnection> logger) : base(connectionString, logger)
        {
            RetryPolicy = policyRegistry;
        }
        public override ISqlPolicyRegistry RetryPolicy { get; }
        protected override SqlConnection GetConnectionObject()
        {
            return new SqlConnection(ConnectionString);    
        }
        private static string ConvertToConnectionString(ConnectionConfig connectionConfig, ILogger logger)
        { 
            if (connectionConfig == null)
            {
                logger.LogWarning($"Creating SqlConnection stirng: {nameof(connectionConfig)} is null");
                return null;
            }

            var builder = new SqlConnectionStringBuilder(connectionConfig.BaseConnectionString)
            {
                DataSource = connectionConfig.DataSource,
                InitialCatalog = connectionConfig.InitialCatalog,
                UserID = connectionConfig.UserId,
                Password = connectionConfig.Password,
                IntegratedSecurity = connectionConfig.IntegratedSecurity
            };
            return builder.ToString();
        }
    }
}
