using Fakestagram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Fakestagram.Services
{
    public class UserService : IUserService
    {
        private readonly FakestagramDBContext _context;

        public UserService(FakestagramDBContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ActionResult<User>> UpdateUserAsync(int id, User user)
        {
            User existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser != null)
            {
                // Update the properties of the existing user
                _context.Entry(existingUser).State = EntityState.Detached;
                _context.Entry(user).State = EntityState.Modified;
                // ...

                await _context.SaveChangesAsync();
            }

            return existingUser; // Return the updated user
        }
        
}
}