using ApplicationCore.Entities.BasketAggregate;
using ApplicationCore.Specifications;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Specifications
{
    public class BasketWithItems
    {
        private readonly int _testBasketId = 123;
        private readonly string _buyerId = "Test BuyerId";

        private readonly SpecificationEvaluator<Basket> _evaluator = new SpecificationEvaluator<Basket>();

        [Fact]
        public void MatchesBasketWithGivenId()
        {
            var spec = new BasketWithItemsSpecification(_testBasketId);
            var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec)
                                        .FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal(_testBasketId, result.Id);
        }

        [Fact]
        public void MatchesNoBasketsIfBasketIdNotPresent()
        {
            int badBasketId = -1;
            var spec = new BasketWithItemsSpecification(badBasketId);
            var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec).Any();
            Assert.False(result);
        }

        [Fact]
        public void MatchesBasketWithGivenBuyerId()
        {
            var spec = new BasketWithItemsSpecification(_testBasketId);
            var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(_testBasketId, result.Id);

        }

        [Fact]
        public void MatchesNoBasketifBuyerIdNotPresent()
        {
            string badBuyerId = "Bad Id";
            var spec = new BasketWithItemsSpecification(badBuyerId);
            var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec).Any();
            Assert.False(result);
        }

        public List<Basket> GetTestBasketCollection()
        {
            var basket1Mock = new Mock<Basket>(_buyerId);
            basket1Mock.SetupGet(s => s.Id).Returns(1);
            var basket2Mock = new Mock<Basket>(_buyerId);
            basket2Mock.SetupGet(s => s.Id).Returns(2);
            var basket3Mock = new Mock<Basket>(_buyerId);
            basket3Mock.SetupGet(s => s.Id).Returns(_testBasketId);

            return new List<Basket>()
            {
                basket1Mock.Object,
                basket2Mock.Object,
                basket3Mock.Object
            };
        }
    }
}
