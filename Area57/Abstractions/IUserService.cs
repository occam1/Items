using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Area57
{
  public  interface IUserService
    {
        Task<long> GetPersonIdByUserName(string username, string password);
        Task<List<RoleLocation>> GetRoleLocationsByPersonId(long personId);
    }
}
