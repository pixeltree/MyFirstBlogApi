using System;
using System.Collections.Generic;
using MyFirstBlog.Models;

namespace MyFirstBlog.Repositories {
    public interface IPostsRepository
    {
        Post GetPost(Guid id);
        IEnumerable<Post> GetPosts();
    }
}
