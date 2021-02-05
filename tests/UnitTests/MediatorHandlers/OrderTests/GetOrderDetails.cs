using ApplicationCore.Entities;
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
using Web.Features.OrderDetails;
using Xunit;

namespace UnitTests.MediatorHandlers.OrderTests
{
    public class GetOrderDetailstests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;

        public GetOrderDetailstests()
        {
            var item = new OrderItem(new CatalogItemOrdered(1,"Product Name","URI"),10.00m,10);
            var address = new Address(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            Order order = new Order("Buyer Id",address,new List<OrderItem> { item });

            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderRepository.Setup(x => x.ListAsync(It.IsAny<ISpecification<Order>>())).ReturnsAsync(new List<Order> { order });
        }

        [Fact]
        public async Task NotBeNullIfOrderExists()
        {
            var request = new GetOrderDetails("Some Name:", 0);
            var handler = new GetOrderDetailsHandler(_mockOrderRepository.Object);
            var result = await handler.Handle(request,CancellationToken.None);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BeNullIfORderNotFound()
        {
            var request = new GetOrderDetails("SomeName",100);
            var handler = new GetOrderDetailsHandler(_mockOrderRepository.Object);
            var result = await handler.Handle(request,CancellationToken.None);
            Assert.Null(result);
        }
    }
}
