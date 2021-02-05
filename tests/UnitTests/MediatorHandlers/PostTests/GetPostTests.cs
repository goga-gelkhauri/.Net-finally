using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web.Features.GetPosts;
using Xunit;

namespace UnitTests.MediatorHandlers.PostTests
{
    public class GetPostTests
    {
        private readonly Mock<IPostRepository> _mockPostRepository;

        public GetPostTests()
        {
            var post = new Post { Id = 1, Name = "Test Post", Description = "Some Descr" };
            _mockPostRepository = new Mock<IPostRepository>();
            _mockPostRepository.Setup(x => x.GetByIdAsync(It.IsInRange(0, 50,Moq.Range.Inclusive))).ReturnsAsync(post);
        }

        [Fact]
        public async Task NotBeNullIfPostExists()
        {
            var request = new GetPostsById(0);
            var handler = new GetPostsByIdHandler(_mockPostRepository.Object);
            var result = await handler.Handle(request,CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task BeNullIfPostNotExists()
        {
            var request = new GetPostsById(100);
            var handler = new GetPostsByIdHandler(_mockPostRepository.Object);
            var result = await handler.Handle(request, CancellationToken.None);

            Assert.Null(result);
        }
    }
}
