using MyFirstBlog.Dtos;
using MyFirstBlog.Models;

namespace MyFirstBlog {
    public static class Extensions {
        public static PostDto AsDto(this Post post) {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                CreatedDate = post.CreatedDate
            };
            
        }
    }
};