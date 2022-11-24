using MyFirstBlog.Models;

namespace MyFirstBlog.Repositories {
    public interface IPostsRepository
    {
        Post GetPost(String slug);
        IEnumerable<Post> GetPosts();
    }
}
