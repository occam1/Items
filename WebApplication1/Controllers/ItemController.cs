using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/Item")]
    [Produces("application/json")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "value1", "value2" });
        }

        //https://localhost:44321/api/Item/GetItems

        /// <summary>
        /// list all the items
        /// </summary>
        /// <returns>Items</returns>
        [HttpGet("GetItems")]
        [ProducesResponseType(typeof(List<Item>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItems()
        {
            List<Item> result = await _itemService.GetItems();
            return Ok(result);
        }
        
    }
}
