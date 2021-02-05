using ApplicationCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Extensions
{
    public class JsonExtensions
    {
        [Fact]
        public void CorrectlySerializesAndDeserializesObject()
        {
            var testParent = new TestParent
            {
                Id = 7,
                Name = "Test Name",
                Children = new[]
                {
                    new TestChild(),
                    new TestChild(),
                    new TestChild()
                }
            };
            var json = testParent.ToJson();
            var result = json.FromJson<TestParent>();
            Assert.Equal(testParent, result);
        }

        [
            Theory,
            InlineData("{ \"id\": 9, \"name\": \"Another test\" }", 9, "Another test"),
            InlineData("{ \"id\": 3124, \"name\": \"Test Value 1\" }", 3124, "Test Value 1"),

        ]
        public void CorrectlyDeserializesJson(string json, int exceptedId, string exceptedName) =>
            Assert.Equal(new TestParent { Id = exceptedId, Name = exceptedName }, json.FromJson<TestParent>());
    }
}
