using System;
using System.Data;
using System.Data.Common;
using Data.Interfaces;

namespace Data
{
    public class DataConnectionTransaction<T> : IDataConnectionTransaction where T : DbConnection
    {
        private readonly DataConnection<T> _dataConnection;
        public IDbTransaction Transaction { get; private set; }

        public DataConnectionTransaction(DataConnection<T> dataConnection, DbTransaction transaction)
        {
            _dataConnection = dataConnection;
            Transaction = transaction;
            _dataConnection.UseTransaction(this);
        }


        public void Dispose()
        {
            Transaction.Dispose();
            _dataConnection.UseTransaction(null);
        }

        public Guid TransactionId { get; } = Guid.NewGuid();

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
            _dataConnection.UseTransaction(null);
        }
    }
}
