using ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Features.DeletePost
{
    public class DeletePost : IRequest<Unit>
    {
        public Post Post { get; set; }
        public DeletePost(Post _post)
        {
            Post = _post;
        }
    }
}
