using AutoMapper;
using Fakestagram.Models;
using Fakestagram.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fakestagram.Controllers
{
    [Route("api/v1/Posts")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        //private readonly FakestagramDBContext _dbContext;
        private readonly IPostsService _postsService;

        public PostController(IMapper mapper, IPostsService postsService) {
            _mapper = mapper;
            _postsService = postsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {

            try
            {
                var post = await _postsService.Get(id);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        // POST: PostController/Create
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
        {
            Post tempPost = _mapper.Map<Post>(post);
            tempPost.Created = DateTime.Now;
            try
            {
                await _postsService.Create(tempPost);
            }
            catch
            {
                throw;
            }

            return tempPost;
        }

        // Edit: PostController/Edit/
        [HttpPost("{id}")]
        public async Task<ActionResult<Post>> Edit(int id, [FromBody] Post post)
        {
            Post tempPost = _mapper.Map<Post>(post);
            tempPost.Updated = DateTime.Now;

            try
            {
                await _postsService.Update(id, tempPost);
            }
            catch (Exception)
            {

                throw;
            }
            return tempPost;
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PostController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PostController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
