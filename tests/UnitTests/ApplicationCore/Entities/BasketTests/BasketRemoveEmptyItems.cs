using ApplicationCore.Entities.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.BasketTests
{
    public class BasketRemoveEmptyItems
    {
        private readonly int _testCatalogItemId = 123;
        private readonly decimal _testUnitPrice = 1.23m;
        private readonly string _buyerId = "Test Buyer ID";

        [Fact]
        public void RemovsEmptyBasketItems()
        {
            var basket = new Basket(_buyerId);
            basket.AddItem(_testCatalogItemId, _testUnitPrice, 0);
            basket.RemoveEmptyItems();

            Assert.Equal(0, basket.Items.Count);
        }
    }
}
