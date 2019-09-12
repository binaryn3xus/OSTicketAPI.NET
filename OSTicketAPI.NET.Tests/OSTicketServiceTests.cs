using System;
using Xunit;

namespace OSTicketAPI.NET.Tests
{
    public class OSTicketServiceTests
    {
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
    }
}
