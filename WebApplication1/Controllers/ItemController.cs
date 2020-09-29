using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        /// <summary>
        /// handle interations with the Area57 database Items table
        /// </summary>
        /// <param name="itemService"></param>
        
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }
        /// <summary>
        /// list all the items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Item>> GetItems()
        {

            return await _itemService.GetItems();
            
        }
    }
}
