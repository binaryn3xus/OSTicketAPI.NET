using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddOSTicketServices(this IServiceCollection services, Action<OSTicketServiceOptions> setupAction)
        {
            var logger = LogProvider.For<OSTicketOfficialApi>();
            logger?.Info("Attempting to load OSTicket settings using {OptionsType}", setupAction?.GetType().Name);
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));

            services.Configure(setupAction);
            return services.AddSingleton<OSTicketService>();
        }

        public static void AddOSTicketServices(this IServiceCollection services, IConfigurationSection customConfigurationSection = null)
        {
            using var sp = services.BuildServiceProvider();
            var logger = LogProvider.For<OSTicketOfficialApi>();
            var configuration = sp.GetService<IConfiguration>();
            var configurationSection = customConfigurationSection ?? configuration?.GetSection("OSTicket");

            if (!configurationSection.Exists())
                throw new ArgumentNullException($"No configurations were setup for {configurationSection?.Key}");

            logger?.Info("Attempting to load OSTicket settings using {OptionsType}", configurationSection?.GetType().Name);
            var connectionString = configurationSection.GetValue<string>("DatabaseConnectionString");
            var baseUrl = configurationSection.GetValue<string>("BaseUrl");
            var apiKey = configurationSection.GetValue<string>("ApiKey");
            services.AddSingleton(new OSTicketService(connectionString, new OSTicketOfficialApi(baseUrl, apiKey)));
        }
    }
}
