using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common.Models;
using Area57.Services;
using Microsoft.AspNetCore.Authorization;

namespace Area57.Controllers
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
        /// <param name="Item"> Dealer ID</param>
        /// <returns>long</returns>
    [Authorize]
        [HttpPost("InsertItem1")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(long), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> InsertItem1([FromBody]Item tmp)
        {
            Item newItem = new Item()
            {
                dealerId = tmp.dealerId,
                name = tmp.name,
                description = tmp.description,
                manufacturer = tmp.manufacturer,
                manufacturingLine = tmp.manufacturingLine,
                keywords = tmp.keywords,
                cost = tmp.cost,
                currentPrice = tmp.currentPrice,
                minimumPrice = tmp.minimumPrice,
                pricingPlanId = tmp.pricingPlanId,
                quantity = tmp.quantity,
                isAvailable = tmp.isAvailable,
                isShippable = tmp.isShippable
            };

            var result = await _itemService.InsertItem(newItem);
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
        /// <param name="Quantity">The number of identical items of similar quality</param>
        /// <param name="IsAvailable">Is the item available for sell right now?</param>
        /// <returns>long</returns>
        [HttpPost("InsertItem")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertItem(long dealerId, string name, string description, string manufacturer,
            string manufacturingLine, string keywords, decimal cost, decimal currentPrice, decimal minimumPrice,
            int pricingPlanId, int quantity, bool isAvailable)
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
               quantity = quantity,
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
        [HttpPost("InsertItemByContainer")]
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
        [HttpPost("InsertItemPicture")]
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

        /// <summary>
        /// list all the items
        /// </summary>
        /// <param name="DealerId" >Your Dealer ID</param>
        /// <param name="ItemId">Item Id</param>
        /// <param name="FurnitureId" >Furniture where item is displayed</param>
        /// <param name="SurfaceId">Display Surface/Shelf of Furniture - optional </param>
        /// <param name="SurfaceAreaId">Area on the Display Surface - optional</param>
        /// <returns>long</returns>
        [HttpPost("AssignItemPlace")]
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


      


/// <summary>
/// Create (insert) a new container
/// </summary>
/// <param name="DealerId" >Your Dealer ID</param>
/// <param name="Name">Container Identifier</param>
/// <param name="Description" >General description  </param>
/// <param name="ContainerType">Material and form; plastic box, glass bowl etc </param>
/// <returns>long</returns>
[HttpPost("InsertContainer")]
[ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
public async Task<IActionResult> InsertContainer(long dealerId, string name, string description,
 int containerType)
{
    Container newContainer = new Container()
    {
        dealerId = dealerId,
        name = name,
        description = description,
        containerType = containerType
    };

    var result = await _itemService.InsertContainer(newContainer);
    return Ok(result);
}
       

      /// <summary>
      /// assign a container to a place in some furniture
      /// </summary>
      /// <param name="DealerId" >Your Dealer ID</param>
      /// <param name="ContainerId">Container ID</param>
      /// <param name="FurnitureId" >Furniture where item is displayed</param>
      /// <param name="SurfaceId">Display Surface/Shelf of Furniture - optional </param>
      /// <param name="SurfaceAreaId">Area on the Display Surface - optional</param>
      /// <returns>long</returns>
      [HttpPost("InsertContainerPlace")]
      [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
      public async Task<IActionResult> AssignContainerPlace(long dealerId, long containerId, long furnitureId,
          long surfaceId, long surfaceAreaId)
      {
          ContainerPlace newContainerPlace = new ContainerPlace()
          {
              dealerId = dealerId,
              containerId = containerId,
              furnitureId = furnitureId,
              surfaceId = surfaceId,
              surfaceAreaId = surfaceAreaId
          };

          var result = await _itemService.AssignContainerPlace(newContainerPlace);
          return Ok(result);
      }

       
             /// <summary>
             /// Assign an item to a container
             /// </summary>
             /// <param name="DealerId" >Your Dealer ID</param>
             /// <param name="ContainerId">Container Identifier</param>
             /// <param name="ItemId" >Item to assign to the container  </param>
             /// <returns>long</returns>
             [HttpPost("AssignItemToContainer")]
             [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
             public async Task<IActionResult> AssignItemToContainer(long dealerId, long containerId, long itemId
             )
             {
                 ContainerItem newContainerItem = new ContainerItem
                 {
                     dealerId = dealerId,
                     containerId = containerId,
                     itemId = itemId
                 };
                 var result = await _itemService.AssignItemToContainer(newContainerItem);
                 return Ok(result);
             }

        
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
             /// <param name="Keywords" >Keywords describing items of interest - comma separated  </param>
             /// <returns>Items</returns>
             [HttpGet("GetItemsByKeyword")]
             [ProducesResponseType(typeof(List<Item>), StatusCodes.Status200OK)]
             public async Task<IActionResult> GetItemsByKeywords(string keywords)
             {
              var result = await _itemService.GetItemsByKeywords(keywords);
              return Ok(result.ToList());
             }
        
             /// <summary>
             /// list all the items
             /// </summary>
             /// <param name="DealerId" >Dealer ID </param>
             /// <returns>Items</returns>
             [HttpGet("GetItemsByDealer")]
             [ProducesResponseType(typeof(List<Item>), StatusCodes.Status200OK)]
             public async Task<IActionResult> GetItemsByDealer(long dealerId)
             {
              var result = await _itemService.GetItemsByDealer(dealerId);
              return Ok(result.ToList());
             }

        
             /// <summary>
             /// get the location of an item
             /// </summary>
             /// <param name="DealerId" >Dealer ID </param>
             /// <param name="DealerId" >Item ID </param>
             /// <returns>Item Place</returns>
             [HttpGet("GetItemPlace")]
             [ProducesResponseType(typeof(ItemPlace), StatusCodes.Status200OK)]
             public async Task<IActionResult> GetItemsByPlace(long dealerId, long itemId)
             {
              var result = await _itemService.GetItemPlace(dealerId, itemId);
              return Ok(result);
             }

             /// <summary>
             /// get the pictures of an item
             /// </summary>
             /// <param name="DealerId" >Dealer ID </param>
             /// <param name="ItemId" >Item ID </param>
             /// <returns>Item Place</returns>
             [HttpGet("GetItemPictures")]
             [ProducesResponseType(typeof(List<ItemPicture>), StatusCodes.Status200OK)]
             public async Task<IActionResult> GetItemPictures(long dealerId, long itemId)
             {
              var result = await _itemService.GetItemPlace(dealerId, itemId);
              return Ok(result);
             }

       

             /// <summary>
             /// get the containers belonging to a dealer
             /// </summary>
             /// <param name="DealerId" >Dealer ID </param>
             /// <returns>Containers</returns>
             [HttpGet("GetContainers")]
             [ProducesResponseType(typeof(List<Container>), StatusCodes.Status200OK)]
             public async Task<IActionResult> GetContainers(long dealerId)
             {
              var result = await _itemService.GetContainers(dealerId);
              return Ok(result);
             }
       
            /// <summary>
            /// get the containers belonging to a dealer
            /// </summary>
            /// <param name="DealerId" >Dealer ID </param>
            /// <param name="ContainerId">Container ID</param>
            /// <returns>ContainerPlace</returns>
            [HttpGet("GetContainerPlace")]
            [ProducesResponseType(typeof(ContainerPlace), StatusCodes.Status200OK)]
            public async Task<IActionResult> GetContainerPlace(long dealerId, long containerId)
            {
             var result = await _itemService.GetContainerPlace(dealerId, containerId);
             return Ok(result);
            }
      

           /// <summary>
           /// get thebitems assigned to a container
           /// </summary>
           /// <param name="DealerId" >Dealer ID </param>
           /// <param name="ContainerId">Container ID</param>
           /// <returns>Items</returns>
           [HttpGet("GetContainerItems")]
           [ProducesResponseType(typeof(List<Item>), StatusCodes.Status200OK)]
           public async Task<IActionResult> GetContainerItems(long dealerId, long containerId)
           {
            var result = await _itemService.GetContainerItems(dealerId, containerId);
            return Ok(result);
           }



           /// <summary>
           /// get the furniture belonging to a dealer
           /// </summary>
           /// <param name="DealerId" >Dealer ID </param>
           /// <returns>Furniture</returns>
           [HttpGet("GetFurniture")]
           [ProducesResponseType(typeof(List<Furniture>), StatusCodes.Status200OK)]
           public async Task<IActionResult> GetFurniture(long dealerId)
           {
            var result = await _itemService.GetFurniture(dealerId);
            return Ok(result);
           }
       
         //Task<List<Surface>> GetSurfaces(long dealerId, long furnitureId);
         /// <summary>
         /// get the display surfaces defined for the furniture
         /// </summary>
         /// <param name="DealerId" >Dealer ID </param>
         /// <param name="FurnitureId">Container ID</param>
         /// <returns>Surfaces</returns>
         [HttpGet("GetSurfaces")]
         [ProducesResponseType(typeof(ContainerPlace), StatusCodes.Status200OK)]
         public async Task<IActionResult> GetSurfaces(long dealerId, long furnitureId)
         {
          var result = await _itemService.GetSurfaces(dealerId, furnitureId);
          return Ok(result);
         }

 
        //Task<List<SurfaceArea>> GetSurfaceAreas(long dealerId, long fur
        /// <summary>
        /// get the areas into which a surface is divided
        /// </summary>
        /// <param name="DealerId" >Dealer ID </param>
        /// <param name="FurnitureId">Furniture ID</param>
        /// <param name="SurfaceId">Surface ID</param>
        /// <returns>SurfaceAreas</returns>
        [HttpGet("GetSurfaceAreas")]
             [ProducesResponseType(typeof(List<SurfaceArea>), StatusCodes.Status200OK)]
             public async Task<IActionResult> GetSurfaceAreas(long dealerId, long furnitureId, long surfaceId)
             {
              var result = await _itemService.GetSurfaceAreas(dealerId, furnitureId, surfaceId);
              return Ok(result);
             }
             
    }
}
