using ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Builders
{
    public class AddressBuilder
    {
        private Address _address;
        public string TestStreet => "123 Main St.";
        public string TestCity => "Los Angeles";
        public string TestState => "California";
        public string TestCountry => "USA";
        public string TestZipCode => "44240";

        public AddressBuilder()
        {
            _address = WithDefaultValues();
        }

        public Address Build()

        {
            return _address;
        }

        public Address WithDefaultValues()
        {
            _address = new Address(TestStreet, TestCity, TestState, TestCountry, TestZipCode);
            return _address;
        }
    }
}
