using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web.Features.MyOrders;
using Xunit;

namespace UnitTests.MediatorHandlers.OrderTests
{
    public class GetMyOrdersTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;

        public GetMyOrdersTests()
        {
            var item = new OrderItem(new CatalogItemOrdered(1, "ProductName", "URI"), 10.00m, 10);
            var address = new Address(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            Order order = new Order("BuyerId", address, new List<OrderItem> { item });

            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderRepository.Setup(x => x.ListAsync(It.IsAny<ISpecification<Order>>())).ReturnsAsync(new List<Order> { order});
        }

        [Fact]
        public async Task NotReturnsNUlIfOrdersArePresent()
        {
            var request = new GetMyOrders("SomeUsername");
            var handler = new GetMyOrdersHandler(_mockOrderRepository.Object);
            var result = await handler.Handle(request,CancellationToken.None);

            Assert.NotNull(result);
        }

    }
}
