using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Models;
using System.Data.Common;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Data.Abstractions.Interfaces;
using WebApplication1.Models;

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
        public async  Task<List<Item>> GetItems()
        {
            return await _dbContext.Area57Repository.GetItems();
        }

        public async Task<List<Item>> GetItemsByKeywords(string keywordList)       
        {
            return await _dbContext.Area57Repository.GetItemsByKeywords(keywordList);
        }
        public async Task<List<Item>> GetItemsByDealer(long dealerId)
        {
            return await _dbContext.Area57Repository.GetItemsByDealer(dealerId);
        }
        public async Task<ItemPlace> GetItemPlace(long dealerId, long itemId)
        {
            return await _dbContext.Area57Repository.GetItemPlace(dealerId, itemId);
        }
        public async Task<List<ItemPicture>> GetItemPictures(long dealerId, long itemId)
        {
            return await _dbContext.Area57Repository.GetItemPictures(dealerId, itemId);
        }
        public async Task<List<Container>> GetContainers(long dealerId)
        {
            return await _dbContext.Area57Repository.GetContainers(dealerId);
        }
        public async Task<ContainerPlace> GetContainerPlaces(long dealerId, long containerId)
        {
            return await _dbContext.Area57Repository.GetContainerPlaces(dealerId, containerId);
        }
        //public async Task<List<Item>> GetItemsByContainer( long containerId)
        //{
        //    return await _dbContext.Area57Repository.GetItemByContainer(containerId);
        //}
        public async Task<List<Furniture>> GetFurniture(long dealerId)
        {

            return await _dbContext.Area57Repository.GetFurniture(dealerId );
        }
        public async Task<List<Surface>> GetSurfaces(long dealerId, long furnitureId)
        {
            
            return await _dbContext.Area57Repository.GetSurfaces(dealerId, furnitureId);
        }
        public async Task<List<SurfaceArea>> GetSurfaceAreas(long dealerId, long furnitureId, long surfaceId)
        {
            return await _dbContext.Area57Repository.GetSurfaceAreas(dealerId, furnitureId, surfaceId);
        }
        public async Task<long> InsertItemByContainer(long containerId, Item newItem, long currentUserId=1)
        {
            return await _dbContext.Area57Repository.InsertItemByContainer(containerId, newItem, currentUserId);
        }
        public async Task<long> InsertItemPicture(ItemPicture newItemPicture, long currentUserId=1)
        {
            return await _dbContext.Area57Repository.InsertItemPicture(newItemPicture, currentUserId);
        }
        public async Task<long> AssignItemPlace(ItemPlace newItemPlace, long currentUserId)
        {
            return await _dbContext.Area57Repository.AssignItemPlace(newItemPlace, currentUserId);
        }
        public async Task<long> InsertContainer(Container newContainer, long currentUserId)
        {
            return await _dbContext.Area57Repository.InsertContainer(newContainer, currentUserId);
        }
        public async Task<long> AssignContainerPlace(ContainerPlace newContainerPlace, long currentUserId)
        {
            return await _dbContext.Area57Repository.AssignContainerPlace(newContainerPlace, currentUserId);
        }
        public async Task<long> InsertItem(Item newItem, long currentUserId = 1)
        {
            return await _dbContext.Area57Repository.InsertItem(newItem, currentUserId);
        }
        public async Task<long> AssignItemToContainer(ContainerItem newContainerItem, long currentUserId)
        {
            return await _dbContext.Area57Repository.AssignItemToContainer(newContainerItem, currentUserId);
        }

        Task<List<Item>> IItemService.GetContainerItems(long dealerId, long containerId)
        {
            throw new NotImplementedException();
        }
    }
}
