using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Extensions;
using Xunit;

namespace UnitTests.Web.Extensions.CacheHelpersTests
{
    public class GenerateTypesCacheKey
    {
        [Fact]
        public void ReturnsTypeCacheKey()
        {
            var result = CacheHelpers.GenerateTypesCacheKey();

            Assert.Equal("types",result);
        }
    }
}
