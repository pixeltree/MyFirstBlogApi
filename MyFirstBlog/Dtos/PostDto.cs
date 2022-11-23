using System;

namespace MyFirstBlog.Dtos {
    public record PostDto {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Body { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
