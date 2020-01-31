using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Helpers;
using OSTicketAPI.NET.Models;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Helpers
{
    public class OSTicketJsonDecoderTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public OSTicketJsonDecoderTests(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        [RunnableInDebugOnly]
        public async Task JsonDecoderTests_ShouldThreadEventMessagesAsync()
        {
            var exceptions = new List<Exception>();
            var tickets = await _fixture.OSTicketService.Tickets.GetTickets().ConfigureAwait(false);
            var ticketsArray = tickets as Ticket[] ?? tickets.ToArray();
            var random = new Random();
            int randomIndex = random.Next(ticketsArray.Length);
            var ticket = ticketsArray[randomIndex];

            foreach (var ticketEvent in ticket.Events)
            {
                if (string.IsNullOrWhiteSpace(ticketEvent.Data))
                    continue;

                _testOutputHelper.WriteLine("Preparing to parse:");
                _testOutputHelper.WriteLine(ticketEvent.Data);
                try
                {
                    var ticketEventString = ticketEvent.ToFriendlyString();
                    _testOutputHelper.WriteLine(ticketEventString);
                    _testOutputHelper.WriteLine("------------------------");
                }
                catch (InvalidOperationException ioeEx)
                {
                    _testOutputHelper.WriteLine(ioeEx.Message);
                    _testOutputHelper.WriteLine(ticketEvent.Data);
                    exceptions.Add(ioeEx);
                }
            }
            Assert.Empty(exceptions);
        }
    }
}
