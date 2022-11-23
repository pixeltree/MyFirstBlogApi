using System;
using System.Collections.Generic;
using System.Linq;
using MyFirstBlog.Dtos;
using MyFirstBlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstBlog.Controllers {
    [ApiController]
    [Route("posts")] // commonly done as "[controller]" which will take the controllers name. Currently both would be "/posts"

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

        // Get /posts/:id
        [HttpGet("{id}")]
        public ActionResult<PostDto> GetPost(Guid id) {
            var post = repository.GetPost(id);

            if (post is null) {
                return NotFound();
            }

            return post.AsDto();
        }
    }
}
