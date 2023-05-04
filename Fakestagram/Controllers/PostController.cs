using AutoMapper;
using Fakestagram.Models;
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
        private readonly FakestagramDBContext _dbContext;

        public PostController(IMapper mapper, FakestagramDBContext dBContext) {
            _mapper = mapper;
            _dbContext = dBContext;
        }
        //// GET: PostController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: PostController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: PostController/Create
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
        {
            Post tempPost = _mapper.Map<Post>(post);
            tempPost.Created = DateTime.Now;
            try
            {
                _dbContext.Posts.Add(tempPost);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return tempPost;
        }

        //// GET: PostController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PostController/Edit/5
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
