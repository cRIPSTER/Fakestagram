using Fakestagram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fakestagram.Services
{
    public class PostService : IPostsService
    {
        private readonly FakestagramDBContext _context;

        public PostService(FakestagramDBContext context)
        {
            _context = context;
        }

        public async Task Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> Get(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ActionResult<Post>> Update(int id, Post post)
        {
            Post oldPost = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (oldPost != null)
            {
                return null; 
            }

            _context.Entry(oldPost).State = EntityState.Detached;
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return post;  

        }
    }
}
