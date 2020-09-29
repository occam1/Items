using System;
using System.Data.SqlClient;

namespace Data
{
    public class ConnectionConfig
    {
        public string BaseConnectionString { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string InitialCatalog { get; set; }
        public string DataSource { get; set; }
        public int ConnectTimeout { get; set; }
        public string GetConnectionString()
        {
            var conn = new SqlConnectionStringBuilder
            {
                UserID = UserId,
                Password = Password,
                DataSource = DataSource,
                InitialCatalog = InitialCatalog,
                IntegratedSecurity = IntegratedSecurity,
                ConnectTimeout = ConnectTimeout
            };
            return conn.ConnectionString;
        }
    }
}
