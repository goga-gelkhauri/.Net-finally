using ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Features.UpdatePost
{
    public class UpdatePost : IRequest<Unit>
    {
        public Post Post { get; set; }
        public UpdatePost(Post post)
        {
            Post = post;
        }
    }
}
