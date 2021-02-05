using ApplicationCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Features.GetAllPosts
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, PostsViewModel>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public async Task<PostsViewModel> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            
            var posts = await _postRepository.ListAllAsync();
            
            if (posts == null)
            {
                return null;
            }

            var postViewModel = new PostsViewModel
            {
                Posts = posts
            };

            return postViewModel;
        }
    }
}
