using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Features.GetPosts
{
    public class GetPostsByIdHandler : IRequestHandler<GetPostsById,Post>
    {
        private readonly IPostRepository _postRepository;

        public GetPostsByIdHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(GetPostsById request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);

            if(post == null)
            {
                return null;
            }


            return post;
        }

    }
}
