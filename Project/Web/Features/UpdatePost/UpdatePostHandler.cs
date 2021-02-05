using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Features.UpdatePost
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost,Unit>
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
           
            await _postRepository.UpdateAsync(request.Post);
            return Unit.Value;
        }
    }
}
