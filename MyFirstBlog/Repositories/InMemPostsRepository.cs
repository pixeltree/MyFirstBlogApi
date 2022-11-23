using System;
using System.Linq;
using System.Collections.Generic;
using MyFirstBlog.Models;

namespace MyFirstBlog.Repositories {

    public class InMemPostsRepository : IPostsRepository
    {
        private readonly List<Post> posts = new() {
            new Post { Id= Guid.NewGuid(), Title = "First Post", Body = "This is the body of the first post.", CreatedDate = DateTimeOffset.UtcNow },
            new Post { Id= Guid.NewGuid(), Title = "Second Post", Body = "Here's the second post. Isn't it fantastic?", CreatedDate = DateTimeOffset.UtcNow },
            new Post { Id= Guid.NewGuid(), Title = "Third Post", Body = "Three is a great number. Possibly the best number.", CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Post> GetPosts()
        {
            return posts;
        }

        public Post GetPost(Guid id)
        {
            return posts.Where(post => post.Id == id).SingleOrDefault();
        }
    }
}
