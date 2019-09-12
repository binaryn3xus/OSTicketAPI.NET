using System;
using Microsoft.Extensions.Configuration;

namespace OSTicketAPI.NET.Tests.Fixtures
{
    public class ConfigurationFixture : IDisposable
    {
        public IConfiguration Configuration { get; }
        public OSTicketService OSTicketService;

        public ConfigurationFixture()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<OSTicketServiceTests>()
                .Build();

            var apiKey = Configuration.GetValue<string>("OSTicket:ApiKey");
            var databaseConnectionString = Configuration.GetValue<string>("OSTicket:DatabaseConnectionString");
            var baseUrl = Configuration.GetValue<string>("OSTicket:BaseUrl");

            if (!string.IsNullOrEmpty(databaseConnectionString) && (!string.IsNullOrWhiteSpace(baseUrl) || !string.IsNullOrWhiteSpace(apiKey)))
                OSTicketService = new OSTicketService(databaseConnectionString, new OSTicketOfficialApi(baseUrl, apiKey));
        }

        public void Dispose()
        {

        }
    }
}
