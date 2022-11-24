using MyFirstBlog.Models;

namespace MyFirstBlog.Repositories {
    public interface IPostsRepository
    {
        Post GetPost(string slug);
        IEnumerable<Post> GetPosts();
    }
}
