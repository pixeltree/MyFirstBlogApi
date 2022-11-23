using System;

namespace MyFirstBlog.Models {
    public record Post {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Body { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
