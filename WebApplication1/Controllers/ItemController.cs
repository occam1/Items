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

        /// <summary>
        /// list all the items
        /// </summary>
        /// <param name="DealerId" >Your Dealer ID</param>
        /// <param name="Name" >What you call the item</param>
        /// <param name="Description">Describe the item</param>
        /// <param name="Manufacturer">Who made the item</param>
        /// <param name="ManufacturingLine">The manufatures name of the line</param>
        /// <param name="Keywords">comma separated list of describing terms</param>
        /// <param name="Cost">What was paid for the item</param>
        /// <param name="CurrentPrice">What you are willing to sell for</param>
        /// <param name="MinimumPrice">The smallest amount you will sell it for</param>
        /// <param name="PricingPlanId">The pricing plan you want to use </param>
        /// <param name="IsAvailable">Is the item available for sell right now?</param>
        /// <returns>long</returns>
        [HttpGet("InsertItem")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertItem(long DealerId, string Name, string Description, string Manufacturer,
            string ManufacturingLine, string Keywords, float Cost, float CurrentPrice, float MinimumPrice,
            int PricingPlanId, bool IsAvailable)
        {
            Item newItem = new Item()
            {
               DealerId =   DealerId,
               Name =   Name,
               Description =   Description,
               Manufacturer =   Manufacturer,
               ManufacturingLine =   ManufacturingLine,
               Keywords =   Keywords,
               Cost =   Cost,
               CurrentPrice =  CurrentPrice,
               MinimumPrice =  MinimumPrice,
               PricingPlanId =  PricingPlanId,
               IsAvailable =  IsAvailable
        };

            long result = await _itemService.InsertItem(newItem);
            return Ok(result);
        } 
        
 
 
    }
}
