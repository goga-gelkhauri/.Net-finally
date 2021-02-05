using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Features.CreatePost;
using Web.Features.DeletePost;
using Web.Features.GetAllPosts;
using Web.Features.GetPosts;
using Web.Features.UpdatePost;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //List of all posts
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var viewModel = await _mediator.Send(new GetAllPosts());
            return View(viewModel);
        }


        //Get Single Post
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Single(int id)
        {
            var post = await _mediator.Send(new GetPostsById(id));
            var viewModel = new SinglePostViewModel
            {
                Name = post.Name,
                Description = post.Description
            };

            return View(viewModel);
        }


        //Create Post
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Store post in database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(CreatePostViewModel request)
        {
                if(!ModelState.IsValid)
                {
                    return View("create", request);
                }
                var post = new Post
                {
                    Name = request.Name,
                    Description = request.Description
                };
                await _mediator.Send(new CreatePost(post));

            return Redirect("index");
        }

        //Edit Post
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var post = await _mediator.Send(new GetPostsById(id));

            if(post == null)
            {
                return NotFound();
            }
            var viewModel = new CreatePostViewModel
            {
                Name = post.Name,
                Description = post.Description
            };

            return View(viewModel);
        }


        //Update Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CreatePostViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View("edit", request);
            }
                if(request.Id != 0)
                {
                    var postInDb = await _mediator.Send(new GetPostsById(request.Id));
                    postInDb.Name = request.Name;
                    postInDb.Description = request.Description;
                    await _mediator.Send(new UpdatePost(postInDb));
                }

            return Redirect("/Post");
        }


        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var postInDb = await _mediator.Send(new GetPostsById(id));
                await _mediator.Send(new DeletePost(postInDb));
            }

            return Redirect("/Post");
        }
    }
}
