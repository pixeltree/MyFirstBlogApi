namespace MyFirstBlog.Repositories;

using MyFirstBlog.Entities;

public interface IPostsRepository
{
    Post GetPost(String slug);
    IEnumerable<Post> GetPosts();
}
