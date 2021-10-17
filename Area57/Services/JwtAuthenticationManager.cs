using Area57;
using Area57.Services;
using Common.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        //private readonly IDictionary<string, string> users = new Dictionary<string, string>
        //{ {"test1","password1" },{"test2","password2" } };
        private readonly string _key;
        private IUserService _userService;

        public JwtAuthenticationManager(string key)
        {
              _key = key;
             
        }

        public async Task<string> Authenticate(string username, string password, IUserService userService) 
        {
            _userService = userService;
            //if(!users.Any( t => t.Key == username && t.Value == password))
            //{
            //    return null;
            //}
            long personId = await validateUser(username, password);
            if (personId == 0)
                { 
                return null; 
                }
            var roleLocations = await getRoleLocations(personId);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            Claim[] cl = new Claim[2];
            cl[0] = (new Claim(ClaimTypes.Name, username));
            foreach (RoleLocation rl in roleLocations)
            {
                cl[1] = (new Claim(ClaimTypes.Role, rl.roleId.ToString() + ',' + rl.locationId.ToString()));
            }
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(cl),
                //new Claim[]
                //{
                //  new Claim(ClaimTypes.Name, username),
                //  new Claim(ClaimTypes.Role, roleLocations[0].role.ToString() + ',' + roleLocations[0].location.ToString())
                //}),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        public async Task<long> validateUser(string userName, string userPassword)
        {
            long personId = 0;
            personId = await _userService.GetPersonIdByUserName(userName, userPassword) ;
            return personId;
        }

        public async Task<List<RoleLocation>> getRoleLocations(long personId)
        {
            
            var roleLocations = await _userService.GetRoleLocationsByPersonId(personId);
            return roleLocations;
        }
    }
}
