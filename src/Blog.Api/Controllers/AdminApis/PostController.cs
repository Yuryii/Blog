using AutoMapper;
using Blog.Core.Domain.Content;
using Blog.Core.Models.Content;
using Blog.Core.SeedWork;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers.AdminApis
{
    [Route("api/admin/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);

        }

        [HttpGet]

        public async Task<IActionResult> GetPosts(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var pagedPosts = await _unitOfWork.Posts.GetPostsPagingAsync(keyword, categoryId, pageIndex, pageSize);
            return Ok(pagedPosts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreateUpdatePostRequest postDto)
        {
            try
            {
                var post = _mapper.Map<Post>(postDto);
                _unitOfWork.Posts.Add(post);
                int result = await _unitOfWork.CompleteAsync();
                return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] CreateUpdatePostRequest postDto)
        {
            try
            {
                var existingPost = await _unitOfWork.Posts.GetByIdAsync(id);
                if (existingPost == null)
                {
                    return NotFound();
                }
                _mapper.Map(postDto, existingPost);
                await _unitOfWork.CompleteAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
