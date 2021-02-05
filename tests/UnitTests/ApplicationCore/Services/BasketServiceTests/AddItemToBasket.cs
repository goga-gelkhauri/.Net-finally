﻿using ApplicationCore.Entities.BasketAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Specifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class AddItemToBasket
    {
        private readonly string _buyerId = "Test BuyerId";
        private readonly Mock<IAsyncRepository<Basket>> _mockBasketRepo;

        public AddItemToBasket()
        {
            _mockBasketRepo = new Mock<IAsyncRepository<Basket>>();
        }

        [Fact]
        public async Task InvokesBasketRepositoryGetByIdAsyncOnce()
        {
            var basket = new Basket(_buyerId);
            _mockBasketRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>())).ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.AddItemToBasket(basket.Id, 1, 1.50m);

            _mockBasketRepo.Verify(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>()), Times.Once);
        }

        [Fact]
        public async Task InvokesBasketRepositoryUpdatesAsync()
        {
            var basket = new Basket(_buyerId);
            basket.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>())).ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await basketService.AddItemToBasket(basket.Id, 1, 1.50m);
            _mockBasketRepo.Verify(x => x.UpdateAsync(basket), Times.Once);
        }
    }
}
