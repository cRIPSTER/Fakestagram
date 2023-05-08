using Fakestagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fakestagram.Services
{
    public interface IPostsService
    {
        public Task Create(Post post);
        public Task<ActionResult<Post>> Update(int id, Post post);
        public Task Delete(Post post);
        public Task<Post> Get(int id);
    }
}
