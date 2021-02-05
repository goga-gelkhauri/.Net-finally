using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Web.Extensions;

namespace UnitTests.Web.Extensions.CacheHelpersTests
{
    public class GenerateBrandsCacheKey
    {
        [Fact]
        public void ReturnsBrandCacheKey()
        {
            var result = CacheHelpers.GenerateBrandsCacheKey();
            Assert.Equal("brand",result);
        }
    }
}
