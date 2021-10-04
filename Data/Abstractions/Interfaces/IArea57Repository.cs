using Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Abstractions.Interfaces
{
    public interface IArea57Repository
    {
        Task<List<Item>> GetItems(CancellationToken cancellationToken = default);
        Task<List<Item>> GetItemsByKeywords(string keywordList, CancellationToken cancellationToken = default);
        Task<List<Item>> GetItemsByDealer(long dealerId, CancellationToken cancellationToken = default);
        Task<ItemPlace> GetItemPlace(long dealerId, long itemId, CancellationToken cancellationToken = default);
        Task<List<ItemPicture>> GetItemPictures(long dealerId, long itemId, CancellationToken cancellationToken = default);
        Task<List<Container>> GetContainers(long dealerId, CancellationToken cancellationToken = default); 
        Task<ContainerPlace> GetContainerPlace(long dealerId, long containerId, CancellationToken cancellationToken = default);
        Task<List<Item>> GetContainerItems(long dealerId, long containerId, CancellationToken cancellationToken = default);
        Task<List<Furniture>> GetFurniture(long dealerId, CancellationToken cancellationToken = default);
        Task<List<Surface>> GetSurfaces(long dealerId, long furnitureId, CancellationToken cancellationToken = default);
        Task<List<SurfaceArea>> GetSurfaceAreas(long dealerId, long furnitureId, long surfaceId, CancellationToken cancellationToken = default);
        Task<long> InsertItem(Item newItem, long currentUserId, CancellationToken cancellationToken = default);
        Task<long> InsertItemByContainer (long ContainerId, Item newItem, long currentUserId, CancellationToken cancellationToken = default);
        Task<long> InsertItemPicture(ItemPicture newItemPicture, long currentUserId, CancellationToken cancellationToken = default);
        Task<long> AssignItemPlace(ItemPlace newItemPlace,  long currentUserId,CancellationToken cancellationToken = default);
        Task<long> InsertContainer(Container newContainer, long currentUserId, CancellationToken cancellationToken = default);
        Task<long> AssignContainerPlace(ContainerPlace newContainerPlace, long currentUserId, CancellationToken cancellationToken = default);
        Task<long> AssignItemToContainer(ContainerItem newContainerItem, long currentUserId, CancellationToken cancellationToken = default);
        //Task<long> InsertFurniture(Item newItem, CancellationToken cancellationToken = default);
        //Task<long> InsertSurface(Item newItem, CancellationToken cancellationToken = default);
        //Task<long> InsertSurfaceArea(Item newItem, CancellationToken cancellationToken = default);
    }
}
