using AutoMapper;
using Blog.Core.Domain.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Core.Models.Content
{
    public class CreateUpdatePostRequest
    {
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public string? Description { get; set; }
        public Guid Thumbnail { get; set; }
        public Guid CategoryId { get; set; }
        public string? Content { get; set; }
        public string? Source { get; set; }
        public string? Tag { get; set; }
        public string? SeoDescription { get; set; }

        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<CreateUpdatePostRequest, Post>();
            }
        }
    }


}
