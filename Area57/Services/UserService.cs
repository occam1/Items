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
using Data.Interfaces;
using Data;

namespace Area57.Services
{
    public class UserService : IUserService
    {
        //private readonly ILogger<ItemService> _logger;
        //private readonly ILoggerFactory _loggerFactory;
        private readonly IDbContext _dbContext;
        public UserService( IDbContext dbContext)
        {
           // _loggerFactory = loggerFactory;
            _dbContext = dbContext;

        }
        public async  Task<long> GetPersonIdByUserName(string username, string password)
        {
            return await _dbContext.Area57Repository.GetPersonIdByUserNamePassword(username, password);
        }
        public async Task<List<RoleLocation>> GetRoleLocationsByPersonId(long personId)
        {
            return await _dbContext.Area57Repository.GetRoleLocationsByPersonId(personId);
        }
    }
}
