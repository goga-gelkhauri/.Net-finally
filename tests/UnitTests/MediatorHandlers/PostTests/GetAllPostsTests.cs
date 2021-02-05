using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web.Features.GetAllPosts;
using Xunit;

namespace UnitTests.MediatorHandlers.PostTests
{
    public class GetAllPostsTests
    {
        private readonly Mock<IPostRepository> _mockPostRepository;

        public GetAllPostsTests()
        {
            var post = new Post { Id = 1, Name = "Test Post", Description = "Some Descr" };
            _mockPostRepository = new Mock<IPostRepository>();
            _mockPostRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(new List<Post> { post});
        }

        [Fact]
        public async Task NotReturnsNullIfPostPresent()
        {
            var request = new GetAllPosts();
            var handler = new GetAllPostsHandler(_mockPostRepository.Object);
            var result = await handler.Handle(request,CancellationToken.None);
            Assert.NotNull(result);
        }
    }
}
