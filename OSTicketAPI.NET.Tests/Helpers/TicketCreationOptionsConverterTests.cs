using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Helpers
{
    public class TicketCreationOptionsConverterTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TicketCreationOptionsConverterTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShouldCreateCorrectJsonTextForTicketCreationOptionsConverter()
        {
            var converter = new TicketCreationOptionsConverter();
            var jsonSerializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var ticketCreationOptions = new TicketCreationOptions("UnitTesting@SampleEmail.com", "Unit Testing",
                "Ticket Subject", "Ticket Message")
            {
                CustomProperties = new Dictionary<string, object>
                {
                    { "computerName", "CTNAD1234567890" },
                    { "phoneNumber", "1234" },
                    { "location", "UnitTesting" }
                }
            };

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                converter.WriteJson(writer, ticketCreationOptions, jsonSerializer);
                _testOutputHelper.WriteLine(sb.ToString());
            }
        }

        [Fact]
        public void ShouldThrowErrorForNullValueInTicketCreationOptionsConverter()
        {
            var converter = new TicketCreationOptionsConverter();
            var jsonSerializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                Assert.Throws<ArgumentException>(() => converter.WriteJson(writer, null, jsonSerializer));
                _testOutputHelper.WriteLine(sb.ToString());
            }
        }
    }
}
