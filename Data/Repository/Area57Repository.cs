using Common.Models;
using Data.Abstractions;
using Data.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Area57Repository : IArea57Repository
    {
        private readonly IDataConnection<SqlConnection> _connection;
        private readonly ILogger<Area57Repository> _logger;

        public Area57Repository(IDataConnection<SqlConnection> connection,
            ILogger<Area57Repository> logger)
        {
            _connection = connection;
            _logger = logger;
        }


    public async Task<List<Item>> GetItems(CancellationToken cancellationToken = default)
        {

            var itemList = await _connection.GetAsync<Item, SqlConnection>(
               sql: "a57.sp_getItems", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
            return itemList.ToList();
        }
        public async Task<List<Item>> GetItemsByKeywords(string keywordList, CancellationToken cancellationToken = default)
        {

            var itemList = await _connection.GetAsync<Item, SqlConnection>(
               sql: "a57.sp_getItemsByKeywords", param: keywordList, 
               commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
            return itemList.ToList();
        }
        public async Task<List<Item>> GetItemsByDealer(long dealerId, CancellationToken cancellationToken = default)
        {

            var itemList = await _connection.GetAsync<Item, SqlConnection>(
               sql: "a57.sp_getItems", param: dealerId, 
               commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
            return itemList.ToList();
        }
        public async Task<long> InsertItem(Item newItem, long currentUserId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_insertItem", param: newItem,
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
     
         
        }
        public async Task<long> InsertItemByContainer(long containerId, Item newItem, long currentUserId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_insertItemByContainer", param: new {containerId, newItem },
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
        async Task<long>  IArea57Repository.AssignContainerPlace(ContainerPlace newContainerPlace,long currentUserid, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_AssignContainerPlace", param: newContainerPlace,
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

       async Task<long> IArea57Repository.AssignItemPlace(ItemPlace newItemPlace,long currentUserId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_AssignContainerPlace", param: newItemPlace,
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<List<Item>> IArea57Repository.GetContainerItems(long dealerId, long containerId, CancellationToken cancellationToken)
        {
            try
            {
                var itemList = await _connection.GetAsync<Item, SqlConnection>(
                 sql: "a57.sp_getItems_by_ContainerId", 
                 commandType: CommandType.StoredProcedure, 
                     cancellationToken: cancellationToken);
                return itemList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<ContainerPlace> IArea57Repository.GetContainerPlaces(long dealerId, long containerId, CancellationToken cancellationToken)
        {
            try
            {
                var containerPlace = await _connection.GetFirstOrDefaultAsync<ContainerPlace, SqlConnection>(
                sql: "a57.sp_getContainerPlaces",
                commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return containerPlace;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<List<Container>> IArea57Repository.GetContainers(long dealerId, CancellationToken cancellationToken)
        {
            try
            {
                var containerList = await _connection.GetAsync<Container, SqlConnection>(
                 sql: "a57.sp_getContainers", param: dealerId,
                 commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken);
                return containerList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<List<Furniture>> IArea57Repository.GetFurniture(long dealerId, CancellationToken cancellationToken)
        {
            try
            {
                var furnitureList = await _connection.GetAsync<Furniture, SqlConnection>(
                 sql: "a57.sp_getFurniture", param: dealerId,
                 commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken);
                return furnitureList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<List<ItemPicture>> IArea57Repository.GetItemPictures(long dealerId, long itemId, CancellationToken cancellationToken)
        {
            try
            {
                var itemPictureList = await _connection.GetAsync<ItemPicture, SqlConnection>(
                 sql: "a57.sp_getItemPictures", param: new {dealerId, itemId},
                 commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken);
                return itemPictureList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<ItemPlace> IArea57Repository.GetItemPlace(long dealerId, long itemId, CancellationToken cancellationToken)
        {
            try
            {
                var containerPlace = await _connection.GetFirstOrDefaultAsync<ItemPlace, SqlConnection>(
                sql: "a57.sp_getContainerPlaces",
                commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return containerPlace;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }



        async Task<List<Surface>> IArea57Repository.GetSurfaces(long dealerId, long furnitureId, CancellationToken cancellationToken)
        {
            try
            {
                var surfaceList = await _connection.GetAsync<Surface, SqlConnection>(
                 sql: "a57.sp_getSurfaces", param: new { dealerId, furnitureId },
                 commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken);
                return surfaceList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        async Task<List<SurfaceArea>> IArea57Repository.GetSurfaceAreas(long dealerId, long furnitureId, long surfaceId, CancellationToken cancellationToken)
        {
            try
            {
                var surfaceAreaList = await _connection.GetAsync<SurfaceArea, SqlConnection>(
                 sql: "a57.sp_getSurfaceAreas", param: new { dealerId, furnitureId, surfaceId },
                 commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken);
                return surfaceAreaList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        async Task<long> IArea57Repository.InsertContainer(Container newContainer, long currentUserId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_insertItem", param: new { newContainer, currentUserId },
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<long> IArea57Repository.AssignItemToContainer(ContainerItem newContainerItem, long currentUserId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_AssignItemToContainer", param: new { newContainerItem, currentUserId },
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<long> IArea57Repository.InsertItemByContainer(long containerId, Item newItem,long currentUserId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_insertItemByContainer", param:new { containerId, newItem, currentUserId },
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<long> IArea57Repository.InsertItemPicture(ItemPicture newItemPicture,long currentUserId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_insertItem", param: new { newItemPicture, currentUserId },
                 commandType: CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
