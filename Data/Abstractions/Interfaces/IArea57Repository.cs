using Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Data.Abstractions.Interfaces
{
    public interface IArea57Repository
    {
      
        Task<List<Item>> GetItems(CancellationToken cancellationToken = default);
        Task<int> InsertItem(Item newItem, CancellationToken cancellationToken = default);
    }
}
