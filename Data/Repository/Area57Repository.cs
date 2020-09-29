using Data.Abstractions;
using Data.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Data.Repository
{
    class Area57Repository : IArea57Repository
    {
        private readonly IDataConnection<SqlConnection> _connection;
        private readonly ILogger<Area57Repository> _logger;

        public Area57Repository(IDataConnection<SqlConnection> connection,
            ILogger<Area57Repository> logger)
        {
            _connection = connection;
            _logger = logger;
        }


    public async Task<List<Item>> GetItems(CancellationToken cancellationToken = default)
        {

            var itemList = await _connection.GetAsync<Item, SqlConnection>(
               sql: "dbo.sp_getItems", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
            return itemList.ToList();
        }
        public async Task<int> InsertItem(Item newItem, CancellationToken cancellationToken = default)
        {
            var result = await _connection.SaveExecuteAsync<SqlConnection>(
             sql: "dbo.sp_insertItem", param: newItem, commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken) ;

     
            return result;
        }
    }
}
