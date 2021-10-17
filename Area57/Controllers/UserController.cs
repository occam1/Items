using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Area57;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IJwtAuthenticationManager _jwtAuthenticationManager { get; }
        public IUserService _userService;

        public UserController(IJwtAuthenticationManager jwtAuthenticationManager, IUserService userService)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(long), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] UserCred userCred) 
        {    
            var token = await  _jwtAuthenticationManager.Authenticate(userCred.userId, userCred.password,_userService);
            if (token == null)
            {
                return Unauthorized();
            }
            string jToken = "{\"token\":\"" + token + "\"}";
            return Ok(jToken);
        }

    }
}
