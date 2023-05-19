using AutoMapper;
using Fakestagram.Models;
using Fakestagram.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fakestagram.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {

            try
            {
                var user = await _userService.GetUserAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync([FromBody] User user)
        {
            User tempUser = _mapper.Map<User>(user);
            tempUser.Created = DateTime.Now;
            try
            {
                await _userService.CreateUserAsync(tempUser);
            }
            catch
            {
                throw;
            }

            return tempUser;
        }

        // Edit: 
        [HttpPost("{id}")]
        public async Task<ActionResult<User>> Edit(int id, [FromBody] User user)
        {
            User tempUser = _mapper.Map<User>(user);
            tempUser.Updated = DateTime.Now;

            try
            {
                await _userService.UpdateUserAsync(id, tempUser);
            }
            catch (Exception)
            {

                throw;
            }
            return tempUser;
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                NotFound();
            }
            else
            {
                await _userService.DeleteUserAsync(user);

            }

        }
    }
}
