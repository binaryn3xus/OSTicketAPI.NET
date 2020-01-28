using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSTicketAPI.NET.DTO;

namespace OSTicketAPI.NET
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddOSTicketServices(this IServiceCollection services, Action<OSTicketServiceOptions> setupAction)
        {
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
            var configuration = sp.GetService<IConfiguration>();
            var configurationSection = customConfigurationSection ?? configuration?.GetSection("OSTicket");

            if (!configurationSection.Exists())
                throw new ArgumentNullException($"No configurations were setup for {configurationSection?.Key}");

            var connectionString = configurationSection.GetValue<string>("DatabaseConnectionString");
            var baseUrl = configurationSection.GetValue<string>("BaseUrl");
            var apiKey = configurationSection.GetValue<string>("ApiKey");
            services.AddSingleton(new OSTicketService(connectionString, new OSTicketOfficialApi(baseUrl, apiKey)));
        }
    }
}
