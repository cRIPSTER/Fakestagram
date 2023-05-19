using Fakestagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fakestagram.Services
{
    public interface IUserService
    {
        public Task CreateUserAsync(User user);
        public Task<ActionResult<User>> UpdateUserAsync(int Id, User user);
        public Task DeleteUserAsync(User user);
        public Task<User> GetUserAsync(int id);
    }
}
