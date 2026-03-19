using AutoMapper;
using Blog.Core.Domain.Content;

namespace Blog.Core.Models.Content
{
    public class PostInListDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public string? Description { get; set; }
        public Guid Thumbnail { get; set; }
        public int ViewCount { get; set; }
        public DateTime? DateCreated { get; set; }
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Post, PostInListDto>();
            }
        }
    }

}
