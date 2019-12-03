using System;
using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class TicketRepositoryTest : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public TicketRepositoryTest(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        [RunnableInDebugOnly]
        public void TicketRepository_GetTickets_ShouldBeAbleToGetAllTickets()
        {
            var tickets = _fixture.OSTicketService.Tickets.GetTickets().Result.OrderBy(o => o.Number).ToList();
            _testOutputHelper.WriteLine("Current ticket count: {0}", tickets);
            Assert.NotEmpty(tickets);
        }

        [RunnableInDebugOnly]
        public async Task TicketRepository_GetTickets_ShouldBePopulatedWithAllRelatedTableData()
        {
            //Might need to change this number when testing
            const int ticketId = 681;
            var tickets = await _fixture.OSTicketService.Tickets.GetTickets(o => o.TicketId == ticketId);
            var ticket = tickets.FirstOrDefault();
            Assert.NotNull(ticket);
            Assert.NotNull(ticket.OstFormEntry);
            Assert.NotNull(ticket.OstDepartment);
            Assert.NotNull(ticket.OstHelpTopic);
            Assert.NotNull(ticket.OstSla);
            Assert.NotNull(ticket.OstThread);
            Assert.NotNull(ticket.OstTicketStatus);
            Assert.NotNull(ticket.OstUser);
        }

        [RunnableInDebugOnly]
        public async Task TicketRepository_GetTickets_ShouldBeAbleToFindTicketsByAFormField()
        {
            //Might need to change this number when testing
            var tickets = await _fixture.OSTicketService.Tickets.GetTickets();
            var customFormItemName = "legacyTicketNumber";
            var foundValues = false;
            foreach (var ticket in tickets)
            {
                if (!ticket.OstFormEntry.OstFormEntryValues.Any(o => o.OstFormField.Name.Equals(customFormItemName, StringComparison.OrdinalIgnoreCase)))
                    continue;

                var formEntryValue = ticket.OstFormEntry.OstFormEntryValues
                    .FirstOrDefault(o => o.OstFormField.Name.Equals(customFormItemName, StringComparison.OrdinalIgnoreCase));
                _testOutputHelper.WriteLine("Ticket #{0} has a {1} of {2}", ticket.Number, customFormItemName, formEntryValue?.Value);
                foundValues = true;
            }
            Assert.True(foundValues);
        }

        [RunnableInDebugOnly]
        public void TicketRepository_GetTicketStatuses_ShouldBeAbleToGetAllTicketStatuses()
        {
            var ticketStatuses = _fixture.OSTicketService.Tickets.GetTicketStatuses().Result;
            Assert.NotNull(ticketStatuses);
        }
    }
}
