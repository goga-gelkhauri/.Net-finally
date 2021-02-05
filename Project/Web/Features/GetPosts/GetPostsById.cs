using ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Features.GetPosts
{
    public class GetPostsById : IRequest<Post>
    {
        public int Id { get; private set; }

        public GetPostsById(int _id)
        {
            Id = _id;
        }
    }
}
