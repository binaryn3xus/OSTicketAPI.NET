using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET
{
    public static class ServicesConfiguration
    {
        public static void AddOSTicketServices(this IServiceCollection services, OSTicketServiceOptions options = null)
        {
            IConfiguration configuration;
            var logger = LogProvider.For<OSTicketOfficialApi>();

            services.AddLogging();
            using (var sp = services.BuildServiceProvider())
            {
                configuration = sp.GetService<IConfiguration>();
            }

            if (options != null)
            {
                logger?.Info("Attempting to load OSTicket settings using {OptionsType}", options.GetType().Name);
                services.AddSingleton(new OSTicketService(options.ConnectionString, new OSTicketOfficialApi(options.BaseUrl, options.ApiKey)));
            }
            else if (configuration != null)
            {
                logger?.Info("Attempting to load OSTicket settings using {OptionsType}", configuration.GetType().Name);
                var connectionString = configuration.GetValue<string>("OSTicket:DatabaseConnectionString");
                var baseUrl = configuration.GetValue<string>("OSTicket:BaseUrl");
                var apiKey = configuration.GetValue<string>("OSTicket:ApiKey");
                services.AddSingleton(new OSTicketService(connectionString, new OSTicketOfficialApi(baseUrl, apiKey)));
            }
            else
            {
                logger?.Error("Unable to set up OSTicketService - No IConfiguration setup OR OSTicketServicesOptions setup.");
                throw new Exception("Unable to set up OSTicketService - No IConfiguration setup OR OSTicketServicesOptions setup.");
            }
        }
    }
}
