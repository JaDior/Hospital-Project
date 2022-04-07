using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The UsersController exposes endpoints for user related actions.
    /// </summary>
    [Authorize]
    [ApiController]
    [AllowAnonymous, Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;

        public UsersController(
            ILogger<UsersController> logger,
            IUserProvider userProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _userProvider = userProvider;
            _mapper = mapper;
        }
   
        [HttpGet("{email}")]
        public async Task<ActionResult<UserDTO>> GetUserByEmailAsync(string email)
        {
            _logger.LogInformation("Request received for GetUserByEmailAsync");

            var user = await _userProvider.GetUserByEmailAsync(email);
            var userDTO = _mapper.Map<UserDTO>(user);

            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUserAsync([FromBody] User userToCreate)
        {
            _logger.LogInformation("Request received for CreateUserAsync");

            var user = await _userProvider.CreateUserAsync(userToCreate);
            var userDTO = _mapper.Map<UserDTO>(user);

            return Created("/users", userDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUserAsync(
            int id,
            [FromHeader(Name = "Authorization")] string bearerToken,
            [FromBody] UserDTO userToUpdate)
        {
            _logger.LogInformation("Request received for update user");

            var user = _mapper.Map<User>(userToUpdate);
            var updatedUser = await _userProvider.UpdateUserAsync(bearerToken, id, user);
            var userDTO = _mapper.Map<UserDTO>(updatedUser);

            return Ok(userDTO);
        }

        [HttpPatch("{email}")]
        public async Task<ActionResult> UpdateUserInfoAsync(string email, [FromBody] Dictionary<string, dynamic> updateObj)
        {
            _logger.LogInformation("Request received for update user data");

            await _userProvider.UpdateUserInfoAsync(email, updateObj);

            return NoContent();
        }
        }
}
