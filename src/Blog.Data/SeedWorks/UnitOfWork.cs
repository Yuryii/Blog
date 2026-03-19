using AutoMapper;
using Blog.Core.Domain.Content;
using Blog.Core.Repositories;
using Blog.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(BlogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Posts = new PostRepository(_context, _mapper);
        }

        public IPostRepository Posts { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
