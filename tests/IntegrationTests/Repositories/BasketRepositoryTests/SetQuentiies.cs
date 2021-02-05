using ApplicationCore.Entities.BasketAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Builders;
using Xunit;

namespace IntegrationTests.Repositories.BasketRepositoryTests
{
    public class SetQuentiies
    {
        private readonly BlogDbContext _catalogContext;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly BasketBuilder BasketBuilder = new BasketBuilder();

        public SetQuentiies()
        {
            var dbOptions = new DbContextOptionsBuilder<BlogDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestCatalog")
                    .Options;
            _catalogContext = new BlogDbContext(dbOptions);
            _basketRepository = new EfRepository<Basket>(_catalogContext);
        }

        [Fact]
        public async Task RemoveEmptyQuantites()
        {
            var basket = BasketBuilder.WithOneBasketItem();
            var basketService = new BasketService(_basketRepository, null);

            await _basketRepository.AddAsync(basket);
            _catalogContext.SaveChanges();

            await basketService.SetQuantities(BasketBuilder.BasketId,new Dictionary<string, int>() {{ BasketBuilder.BasketId.ToString(), 0 } });

            Assert.Equal(0, basket.Items.Count);
        }
    }
}
