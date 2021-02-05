using ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Features.CreatePost
{
    public class CreatePost : IRequest<Post>
    {
        public Post Post { get; set; }

        public CreatePost(Post post)
        {
            Post = post;
        }
    }
}
