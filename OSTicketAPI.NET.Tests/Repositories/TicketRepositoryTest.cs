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
        public async Task TicketRepository_GetTickets_ShouldBeAbleToGetASingleTicketId()
        {
            var ticket = _fixture.OSTicketService.Tickets.GetTickets().Result.First();
            var singleTicket = await _fixture.OSTicketService.Tickets.GetTicketByTicketId(ticket.TicketId).ConfigureAwait(false);
            Assert.NotNull(singleTicket);
        }

        [RunnableInDebugOnly]
        public async Task TicketRepository_GetTickets_ShouldBeAbleToGetASingleTicketNumber()
        {
            var ticket = _fixture.OSTicketService.Tickets.GetTickets().Result.First();
            var singleTicket = await _fixture.OSTicketService.Tickets.GetTicketByTicketNumber(ticket.Number).ConfigureAwait(false);
            Assert.NotNull(singleTicket);
        }

        [RunnableInDebugOnly]
        public async Task TicketRepository_GetTickets_ShouldBeAbleToGetTicketData()
        {
            var ticketId = _fixture.OSTicketService.Tickets.GetTickets().Result.First().TicketId;
            var tickets = await _fixture.OSTicketService.Tickets.GetTickets(o => o.TicketId == ticketId);
            var ticket = tickets.FirstOrDefault();
            Assert.NotNull(ticket);
        }

        [RunnableInDebugOnly]
        public void TicketRepository_GetTickets_TicketServiceCountShouldMatchDatabaseCount()
        {
            var dbTicketCount = _fixture.OSTicketService.OstTicketContext.OstTicket.Count();
            var serviceTicketCount = _fixture.OSTicketService.Tickets.GetTickets().Result.Count();
            Assert.Equal(dbTicketCount, serviceTicketCount);
        }

        [RunnableInDebugOnly]
        public void TicketRepository_GetTicketStatuses_ShouldBeAbleToGetAllTicketStatuses()
        {
            var ticketStatuses = _fixture.OSTicketService.Tickets.GetTicketStatuses().Result;
            Assert.NotNull(ticketStatuses);
        }
    }
}
