using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Extensions;
using Xunit;

namespace UnitTests.Web.Extensions.CacheHelpersTests
{
    public class GenerateCatalogItemCacheKey
    {
        [Fact]
        public void ReturnsCatalogItemCacheKey()
        {
            var pageIndex = 0;
            int? brandId = null;
            int? typeId = null;
            var result = CacheHelpers.GenerateCatalogItemCacheKey(pageIndex, 10, brandId, typeId);

            Assert.Equal("items-0-10--", result);
        }
    }
}
