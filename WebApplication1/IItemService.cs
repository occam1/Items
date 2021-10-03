using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace WebApplication1
{
  public  interface IItemService
    {
        Task<List<Item>> GetItems();
        Task<List<Item>> GetItemsByKeywords(string keywordList);
        Task<List<Item>> GetItemsByDealer(long dealerId);
        Task<ItemPlace> GetItemPlace(long dealerId, long itemId);
        Task<List<ItemPicture>> GetItemPictures(long dealerId, long itemId);
        Task<List<Container>> GetContainers(long dealerId);
        Task<ContainerPlace> GetContainerPlaces(long dealerId, long containerId);
        Task<List<Item>> GetContainerItems(long dealerId, long containerId);
        Task<List<Furniture>> GetFurniture(long dealerId);
        Task<List<Surface>> GetSurfaces(long dealerId, long furnitureId);
        Task<List<SurfaceArea>> GetSurfaceAreas(long dealerId, long furnitureId, long surfaceId);
        Task<long> InsertItem(Item newItem, long currentUserId = 1);
        Task<long> InsertItemByContainer( long containerId, Item newItem, long currentUserId=1);
        Task<long> InsertItemPicture( ItemPicture newItemPicture, long currentUserId=1);
        Task<long> AssignItemPlace( ItemPlace newItemPlace, long currentUserId=1);
        Task<long> InsertContainer( Container newContainer, long currentUserId=1);
        Task<long> AssignContainerPlace( ContainerPlace newContainerPlace, long currentUserId=1);
        Task<long> AssignItemToContainer( ContainerItem newContainerItem, long currentUserId=1);

    }
}
