using System;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Repositories;

namespace OSTicketAPI.NET
{
    public class OSTicketService
    {
        public ITicketRepository Tickets { get; set; }
        public IUserRepository Users { get; set; }
        public IHelpTopicsRepository HelpTopics { get; set; }
        public IOSTicketOfficialApi OSTicketOfficialApi { get; }

        public OSTicketService(string databaseServer, string databaseUsername, string databasePassword, string databaseName, IOSTicketOfficialApi osTicketOfficialApi, int portNumber = 3306)
        {
            if (string.IsNullOrWhiteSpace(databaseServer))
                throw new ArgumentException("Database server cannot be null or empty", nameof(databaseServer));
            if (string.IsNullOrWhiteSpace(databaseUsername))
                throw new ArgumentException("Database username cannot be null or empty", nameof(databaseServer));
            if (string.IsNullOrWhiteSpace(databasePassword))
                throw new ArgumentException("Database password cannot be null or empty", nameof(databaseServer));
            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentException("Database name cannot be null or empty", nameof(databaseServer));

            var osticketContext =
                BuildOSTicketContext(
                    $"server={databaseServer};uid={databaseUsername};pwd={databasePassword};database={databaseName};port={portNumber};Convert Zero Datetime=True;");

            OSTicketOfficialApi = osTicketOfficialApi;
            Tickets = new TicketRepository(osticketContext);
            Users = new UserRepository(osticketContext);
            HelpTopics = new HelpTopicsRepository(osticketContext);
        }

        public OSTicketService(string connectionString, IOSTicketOfficialApi osTicketOfficialApi)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty", nameof(connectionString));

            var osticketContext = BuildOSTicketContext(connectionString);

            OSTicketOfficialApi = osTicketOfficialApi;
            Tickets = new TicketRepository(osticketContext);
            Users = new UserRepository(osticketContext);
            HelpTopics = new HelpTopicsRepository(osticketContext);
        }

        private static OSTicketContext BuildOSTicketContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OSTicketContext>();
            optionsBuilder.UseMySQL(connectionString);
            return new OSTicketContext(optionsBuilder.Options);
        }
    }
}
