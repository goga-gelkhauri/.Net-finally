using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Features.GetAllPosts
{
    public class GetAllPosts : IRequest<PostsViewModel>
    {
    }
}
