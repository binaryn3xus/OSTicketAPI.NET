using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Helpers;
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
        private readonly bool _createTicketsDuringTesting;
        private readonly string _creatingTicketUsername;
        private readonly bool _updateTicketsDuringTesting;
        private readonly int _updateTicketId;

        public TicketRepositoryTest(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
            _createTicketsDuringTesting = bool.Parse(_fixture.Configuration["UnitTestSettings:CreateTickets"]);
            _creatingTicketUsername = _fixture.Configuration["UnitTestSettings:CreatingTicketUser"];
            _updateTicketsDuringTesting = bool.Parse(_fixture.Configuration["UnitTestSettings:UpdateTickets"]);
            _updateTicketId = int.Parse(_fixture.Configuration["UnitTestSettings:UpdateTicketId"]);
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

        [RunnableInDebugOnly]
        public async Task TicketRepository_CreateNewTicket_ShouldSuccessfullyCreateANewTicket()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (!_createTicketsDuringTesting)
            {
                _testOutputHelper.WriteLine("Did NOT attempt to create new ticket.");
                return;
            }

            var osTicketUser = await _fixture.OSTicketService.Users.GetUserByUsername(_creatingTicketUsername).ConfigureAwait(false);

            if (osTicketUser == null)
            {
                throw new Exception("OsTicket User Not Found");
            }

            var ticketOptions =
                new TicketCreationOptions(osTicketUser.Email, osTicketUser.Name,
                    "This is a test Ticket created from source code testing.",
                    "This is a test Ticket created from source code testing.")
                {
                    MessageContentType = ContentType.PlainText,
                    Alert = false,
                    AutoRespond = false,
                    IpAddress = "1.1.1.1",
                    Priority = 2,
                    Source = "API",
                    TopicId = 1
                };

            try
            {
                var response = await _fixture.OSTicketService.OSTicketOfficialApi.CreateTicket(ticketOptions).ConfigureAwait(false);
                _testOutputHelper.WriteLine($"{response.StatusCode}:{response.ReasonPhrase}");
                Assert.True(response.IsSuccessStatusCode);
            }
            catch (Exception e)
            {
                _testOutputHelper.WriteLine(e.Message);
                throw;
            }
        }

        [RunnableInDebugOnly]
        public async Task TicketRepository_UpdateATicket_ShouldSuccessfullyUpdateATicket()
        {
            if (!_updateTicketsDuringTesting)
            {
                _testOutputHelper.WriteLine("Did NOT attempt to update ticket.");
                return;
            }

            var ticket = await _fixture.OSTicketService.Tickets.GetTicketByTicketId(_updateTicketId);

            if (ticket == null)
            {
                throw new Exception("OsTicket Ticket Not Found");
            }

            var lastUpdateTime = ticket.LastUpdate;
            ticket.LastUpdate = DateTime.Now;
            var response = await _fixture.OSTicketService.Tickets.UpdateTicketByIdAsync(ticket.TicketId, ticket);
            Assert.True(lastUpdateTime < response.LastUpdate);
        }
    }
}
