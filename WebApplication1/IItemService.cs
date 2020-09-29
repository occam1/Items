using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
  public  interface IItemService
    {
        Task<List<Item>> GetItems();
        Task<int> InsertItem(Item newItem);
    }
}
