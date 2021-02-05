using ApplicationCore.Entities.BasketAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Builders
{
    public class BasketBuilder
    {
        private Basket _basket;
        public string BasketBuyerId => "testbuyerid@test.com";
        public int BasketId => 1;

        public BasketBuilder()
        {
            _basket = WithNoItems();
        }

        public Basket Build()
        {
            return _basket;
        }

        public Basket WithNoItems()
        {
            var basketMock = new Mock<Basket>(BasketBuyerId);
            basketMock.Setup(s => s.Id).Returns(BasketId);

            _basket = basketMock.Object;
            return _basket;
        }

        public Basket WithOneBasketItem()
        {
            var basketMock = new Mock<Basket>(BasketBuyerId);
            _basket = basketMock.Object;
            _basket.AddItem(2, 3.40m, 4);
            return _basket;

        }
    }
}
