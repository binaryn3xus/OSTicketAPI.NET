using OSTicketAPI.NET.Helpers;
using Xunit;

namespace OSTicketAPI.NET.Tests.Helpers
{
    public class ContentTypeTests
    {
        [Fact]
        public void ContentTypesShouldMatchTheAppropriateStringType()
        {
            var htmlContentType = ContentType.Html;
            Assert.Equal("text/html", htmlContentType.Value);

            var plainTextContentType = ContentType.PlainText;
            Assert.Equal("text/plain", plainTextContentType.Value);
        }
    }
}
