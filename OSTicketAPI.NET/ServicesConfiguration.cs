using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OSTicketAPI.NET
{
    public static class ServicesConfiguration
    {
        public static void AddOSTicketServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            if (configuration == null)
            {
                using (var sp = services.BuildServiceProvider())
                {
                    configuration = sp.GetService<IConfiguration>();
                }
            }

            var connectionString = configuration.GetValue<string>("OSTicket:DatabaseConnectionString");
            var baseUrl = configuration.GetValue<string>("OSTicket:BaseUrl");
            var apiKey = configuration.GetValue<string>("OSTicket:ApiKey");

            services.AddSingleton(new OSTicketInstance(connectionString, new OSTicketOfficalApi(baseUrl, apiKey)));
        }
    }
}
