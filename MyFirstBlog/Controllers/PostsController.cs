using MyFirstBlog.Dtos;
using MyFirstBlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstBlog.Controllers {
    [ApiController]
    [Route("posts")]

    public class PostsController : ControllerBase {
        private readonly IPostsRepository repository;

        public PostsController(IPostsRepository repository) {
            this.repository = repository;
        }

        // Get /posts
        [HttpGet]
        public IEnumerable<PostDto> GetPosts() {
            var posts = repository.GetPosts().Select(post => post.AsDto());
            
            return posts;
        }

        // Get /posts/:slug
        [HttpGet("{slug}")]
        public ActionResult<PostDto> GetPost(string slug) {
            var post = repository.GetPost(slug);

            if (post is null) {
                return NotFound();
            }

            return post.AsDto();
        }
    }
}
