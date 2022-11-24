using MyFirstBlog.Models;

namespace MyFirstBlog.Repositories {

    public class InMemPostsRepository : IPostsRepository
    {
        private readonly List<Post> posts = new() {
            new Post { Id= Guid.NewGuid(), Title = "First Post", Slug = "first-post", Body = "This is the body of the first post.", CreatedDate = DateTimeOffset.UtcNow },
            new Post { Id= Guid.NewGuid(), Title = "Second Post", Slug = "second-post", Body = "Here's the second post. Isn't it fantastic?", CreatedDate = DateTimeOffset.UtcNow },
            new Post { Id= Guid.NewGuid(), Title = "Third Post", Slug = "third-post", Body = "Three is a great number. Possibly the best number.", CreatedDate = DateTimeOffset.UtcNow },
            new Post { Id= Guid.NewGuid(), Title = "Fourth Post", Slug = "fourth-post", Body = "This is the fourth post.", CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Post> GetPosts()
        {
            return posts;
        }

        public Post GetPost(string slug)
        {
            return posts.Where(post => post.Slug == slug).SingleOrDefault();
        }
    }
}
