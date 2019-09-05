using OSTicketAPI.NET.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Helpers
{
    public class StringExtensionsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public StringExtensionsTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShouldConvertTextToCamelCase()
        {
            var stringValue = "CamelCaseTest".ToCamelCase();
            _testOutputHelper.WriteLine($"stringValue: {stringValue}");
            Assert.Equal("camelCaseTest", stringValue);
        }

        [Fact]
        public void ShouldReturnNullForToCamelCase()
        {
            const string stringValue = null;
            _testOutputHelper.WriteLine($"stringValue: {stringValue}");
            Assert.Null(stringValue.ToCamelCase());
        }
    }
}
