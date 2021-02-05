using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Entities.CatalogItemTests
{
    public class UpdateDetails
    {
        private CatalogItem _testItem;
        private int _validTypeId = 1;
        private int _validBrandId = 2;
        private string _validDescription = "test desciription";
        private string _validName = "Test Name";
        private decimal _validPrice = 1.23m;
        private string _validUri = "/123";

        public UpdateDetails()
        {
            _testItem = new CatalogItem(_validTypeId, _validBrandId, _validDescription, _validName, _validPrice, _validUri);
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyName()
        {
            string newVal = "";
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(newVal, _validDescription, _validPrice));
        }

        [Fact]
        public void ThrowsArgumentExceptionGivenEmptyDescription()
        {
            string newDesc = "";
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, newDesc, _validPrice));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullName()
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(null,_validDescription,_validPrice));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullDescription()
        {
            Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(_validName, null, _validPrice));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1.23)]
        public void ThrowsArgumentExceptionGivenNonPositivePrice(decimal newPrice)
        {
            Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, _validDescription, newPrice));
        }

    }
}
