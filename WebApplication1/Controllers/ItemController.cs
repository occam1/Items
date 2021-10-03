using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common.Models;
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
            var result = await _itemService.GetItems();
            return Ok(result.ToList());
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
        public async Task<IActionResult> InsertItem(long dealerId, string name, string description, string manufacturer,
            string manufacturingLine, string keywords, decimal cost, decimal currentPrice, decimal minimumPrice,
            int pricingPlanId, bool isAvailable)
        {
            Item newItem = new Item()
            {
               dealerId =   dealerId,
               name =   name,
               description =   description,
               manufacturer =   manufacturer,
               manufacturingLine =   manufacturingLine,
               keywords =   keywords,
               cost =   cost,
               currentPrice =  currentPrice,
               minimumPrice =  minimumPrice,
               pricingPlanId =  pricingPlanId,
               isAvailable =  isAvailable
        };

            var result = await _itemService.InsertItem( newItem);
            return Ok(result);
        }

        /// <summary>
        /// list all the items
        /// </summary>
        /// <param name="DealerId" >Your Dealer ID</param>
        /// <param name="containerId">Desired Container Id</param>
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
        [HttpGet("InsertItemByContainer")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertItemByContainer(long dealerId, long containerId, string name, string description, string manufacturer,
            string manufacturingLine, string keywords, decimal cost, decimal currentPrice, decimal minimumPrice,
            int pricingPlanId, bool isAvailable)
        {
            Item newItem = new Item()
            {
                dealerId = dealerId,
                name = name,
                description = description,
                manufacturer = manufacturer,
                manufacturingLine = manufacturingLine,
                keywords = keywords,
                cost = cost,
                currentPrice = currentPrice,
                minimumPrice = minimumPrice,
                pricingPlanId = pricingPlanId,
                isAvailable = isAvailable
            };

            var result = await _itemService.InsertItemByContainer (containerId, newItem);
            return Ok(result);
        }

        /// <summary>
        /// list all the items
        /// </summary>
        /// <param name="DealerId" >Your Dealer ID</param>
        /// <param name="ItemId">Item Id</param>
        /// <param name="altText" >Display if picture cannot be displayed</param>
        /// <param name="caption1">Caption </param>
        /// <param name="caption2">Additional caption if needed</param>
        /// <param name="path"> Relative path to the picture</param>
        /// <returns>long</returns>
        [HttpGet("InsertItemPicture")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertItemPicture(long dealerId, long itemId, string altText, 
            string caption1, string caption2, string path)        {
            ItemPicture newItemPicture = new ItemPicture()
            {
                dealerId = dealerId,
                itemId = itemId,
                altText = altText,
                caption1 = caption1,
                caption2 = caption2,
                path = path
            };

            var result = await _itemService.InsertItemPicture(newItemPicture);
            return Ok(result);
        }

        Task<long> AssignItemPlace(ItemPlace newItemPlace, long currentUserId = 1);
        /// <summary>
        /// list all the items
        /// </summary>
        /// <param name="DealerId" >Your Dealer ID</param>
        /// <param name="ItemId">Item Id</param>
        /// <param name="FurnitureId" >Furniture where item is displayed</param>
        /// <param name="SurfaceId">Display Surface/Shelf of Furniture - optional </param>
        /// <param name="SurfaceAreaId">Area on the Display Surface - optional</param>
        /// <returns>long</returns>
        [HttpGet("AssignItemPlace")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignItemPlace(long dealerId, long itemId, long furnitureId,
            long? surfaceId, long? surfaceAreaId)
        {
            ItemPlace newItemPlace = new ItemPlace()
            {
                dealerId = dealerId,
                itemId = itemId,
                furnitureId = furnitureId,
                surfaceId = surfaceId,
                surfaceAreaId = surfaceAreaId
            };

            var result = await _itemService.AssignItemPlace(newItemPlace);
            return Ok(result);
        }




        //Task<long> InsertContainer(Container newContainer, long currentUserId = 1);
        //Task<long> AssignContainerPlace(ContainerPlace newContainerPlace, long currentUserId = 1);
        //Task<long> AssignItemToContainer(ContainerItem newContainerItem, long currentUserId = 1);

    }
}
