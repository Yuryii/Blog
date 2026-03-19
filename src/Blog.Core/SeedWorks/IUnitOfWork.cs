using Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.SeedWork
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        Task<int> CompleteAsync();
    }
}
