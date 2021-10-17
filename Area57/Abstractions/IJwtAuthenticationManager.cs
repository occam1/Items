using Area57;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IJwtAuthenticationManager
    {
      Task<string> Authenticate(string username, string password, IUserService userService);
    }
}
