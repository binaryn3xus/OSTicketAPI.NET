﻿using System.Linq;
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
        public async Task TicketRepository_GetTickets_ShouldBeGettingAllTickets()
        {
            var rawDbTickets = _fixture.OSTicketService.OstTicketContext.OstTicket.Count();
            var processedTickets = await _fixture.OSTicketService.Tickets.GetTickets().ConfigureAwait(false);
            _testOutputHelper.WriteLine($"{rawDbTickets} DB Entries and {processedTickets.Count()} collected tickets");
            Assert.Equal(rawDbTickets, processedTickets.Count());
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
            var tickets = await _fixture.OSTicketService.Tickets.GetTickets(o => o.TicketId == ticketId).ConfigureAwait(false);
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
