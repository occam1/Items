using Common.Models;
using Data.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;
using Dapper;

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
            long? newItemId  = null;
            try
            {
                var result = await _connection.SaveExecuteAsync<SqlConnection>(
                 sql: "a57.sp_insertItem", param: new { newItem.dealerId,
                     newItem.name,
                     newItem.keywords,
                     newItem.description,
                     newItem.manufacturer,
                     newItem.manufacturingLine,
                     newItem.cost,
                     newItem.currentPrice,
                     newItem.minimumPrice,
                     newItem.pricingPlanId,
                     newItem.isAvailable,
                     newItem.soldDate,
                     newItem.soldPrice,
                     newItem.isShippable,
                     newItem.quantity,
                     currentUserId, 
                     newItemId },
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

        async Task<ContainerPlace> IArea57Repository.GetContainerPlace(long dealerId, long containerId, CancellationToken cancellationToken)
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
        public async Task<List<RoleLocation>> GetRoleLocationsByPersonId(long personId, CancellationToken cancellationToken = default)
        {
            try
            {
                var rll = await _connection.GetAsync<RoleLocation, SqlConnection>(
                sql: "a57.sp_getRoleLocations_by_PersonId", param: new { PersonId = personId },
                    commandType: CommandType.StoredProcedure,
                 cancellationToken: cancellationToken);

                return rll.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<long> GetPersonIdByUserName(string userName,  CancellationToken cancellationToken = default)
        {
            try
            {
                
                //var p = new DynamicParameters();
                //p.Add("@UserName", userName);
                //p.Add("@personId", dbType: DbType.Int64, direction: ParameterDirection.Output);

                long personId = await _connection.GetFirstOrDefaultAsync<int, SqlConnection>(
                 sql: "a57.sp_GetPersonId_by_UserName", param: new { UserName = userName },
                     commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken);

                return personId;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public async Task<long> GetPersonIdByUserNamePassword(string userName, string password, CancellationToken cancellationToken=default)
        {
                long personId = 0;
            //var p = new DynamicParameters();
            //p.Add("@UserName", userName);
            //p.Add("@Password", password);
            //p.Add("@personId", dbType: DbType.Int64, direction: ParameterDirection.Output);
            try
            {
                personId = await GetPersonIdByUserName(userName, cancellationToken);
                byte[] salt = await GetSalt(personId, cancellationToken);
                var passwordHash = Convert.ToBase64String(HashPassword(password, salt));
                personId = await _connection.GetFirstOrDefaultAsync<long, SqlConnection>(
                 sql: "a57.sp_GetPersonId_by_UserName_Password", param: new { 
                     UserName = userName
                   ,PasswordHash = passwordHash
                 },
                 commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken); 
                
                return personId;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        private async Task<byte[]> GetSalt(long personId,  CancellationToken cancellationToken)
        {
            try
            {
                string b64 = await _connection.GetFirstOrDefaultAsync<string, SqlConnection>(
                sql: "a57.sp_getDocument_By_PersonId", param: new { PersonId = personId },
                    commandType: CommandType.StoredProcedure,
                 cancellationToken: cancellationToken);
                byte[] baSalt = Convert.FromBase64String(b64);
                return baSalt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return  argon2.GetBytes(16);

            /*
             TABLE [a57].[Cart](
            	[Id] [bigint] personId,
	            [Orders] [bigint] NOT NULL, dop
	            [Items] [bigint] NOT NULL, its
	            [Dollars] money not null, 36Ccup
                [Document] varBinary  nacl
             */
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
