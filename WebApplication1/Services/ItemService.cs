using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Data.Common;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Data.Abstractions.Interfaces;

namespace WebApplication1.Services
{
    public class ItemService : IItemService
    {
        //private readonly ILogger<ItemService> _logger;
        //private readonly ILoggerFactory _loggerFactory;
        private readonly IDbContext _dbContext;
        public ItemService( IDbContext dbContext)
        {
           // _loggerFactory = loggerFactory;
            _dbContext = dbContext;

        }
        public Task<List<Item>> GetItems()
        {
            return _dbContext.Area57Repository.GetItems();
        }
        public Task<int> InsertItem(Item newItem)
        {
            return _dbContext.Area57Repository.InsertItem(newItem);
        }
    }
}
