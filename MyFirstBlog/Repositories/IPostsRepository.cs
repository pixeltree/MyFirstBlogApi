namespace MyFirstBlog.Repositories;

using MyFirstBlog.Models;
using MyFirstBlog.Helpers;

public interface IPostsRepository
{
    Post GetPost(String slug);
    IEnumerable<Post> GetPosts();
}
