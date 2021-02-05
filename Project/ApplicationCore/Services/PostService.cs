using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PostService : IPostService
    {
        private readonly IAsyncRepository<Post> _postRepository;

        public PostService(IAsyncRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task CreatePostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
        }

        public async Task<IReadOnlyList<Post>> ListAllAsync()
        {
            return await _postRepository.ListAllAsync();
        }
    }
}
