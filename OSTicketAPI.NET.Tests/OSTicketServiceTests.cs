﻿using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using OSTicketAPI.NET.Tests.Attributes;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests
{
    public class OSTicketServiceTests
    {
        private IConfiguration Configuration { get; }
        private readonly OSTicketService _osTicketService;
        private readonly ITestOutputHelper _testOutputHelper;

        public OSTicketServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<OSTicketServiceTests>()
                .Build();

            var apiKey = Configuration.GetValue<string>("OSTicket:ApiKey");
            var databaseConnectionString = Configuration.GetValue<string>("OSTicket:DatabaseConnectionString");
            var baseUrl = Configuration.GetValue<string>("OSTicket:BaseUrl");

            if(!string.IsNullOrEmpty(databaseConnectionString) && (!string.IsNullOrWhiteSpace(baseUrl) || !string.IsNullOrWhiteSpace(apiKey)))
                _osTicketService = new OSTicketService(databaseConnectionString, new OSTicketOfficialApi(baseUrl, apiKey));
        }

        [Fact]
        public void ErrorIfConnectionStringIsNull()
        {
            Assert.Throws<ArgumentException>(() => new OSTicketService(null, null));
        }

        [Fact]
        public void ErrorIfAnyDatabaseParametersAreNull()
        {
            Assert.Throws<ArgumentException>(() => new OSTicketService(null, "username", "password", "databaseName", null));
            Assert.Throws<ArgumentException>(() => new OSTicketService("database", null, "password", "databaseName", null));
            Assert.Throws<ArgumentException>(() => new OSTicketService("database", "username", null, "databaseName", null));
            Assert.Throws<ArgumentException>(() => new OSTicketService("database", "username", "password", null, null));
        }

        #region EnvironmentalDebugTests

        [RunnableInDebugOnly]
        public void ShouldBeAbleToGetAllTickets()
        {
            var tickets = _osTicketService.Tickets.GetTickets().Result.ToList();
            _testOutputHelper.WriteLine("Current ticket count: {0}", tickets);
            Assert.True(tickets.Count > 0);
        }

        [RunnableInDebugOnly]
        public void ShouldBeAbleToGetAllTicketStatuses()
        {
            var ticketStatuses = _osTicketService.Tickets.GetTicketStatuses().Result;
            Assert.NotNull(ticketStatuses);
        }

        #endregion
    }
}